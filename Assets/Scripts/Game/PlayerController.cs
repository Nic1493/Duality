using System.Collections;
using UnityEngine;
using static CoroutineHelper;

public class PlayerController : MonoBehaviour
{
    const int PlayerCount = 2;
    Player[] players = new Player[PlayerCount];

    Vector2 inputDirection;

    public event System.Action MoveAction;

    IEnumerator moveCoroutine;
    const float MoveDuration = 0.1f;

    IEnumerator inputDelayCoroutine;
    const float InputRepeatDelay = 0.25f;

    void Awake()
    {
        players = GetComponentsInChildren<Player>();
        FindObjectOfType<Goal>().PlayerInGoalAction += OnPlayerEnterGoal;
    }

    void Update()
    {
        GetMoveDirection();

        if (inputDirection.x != 0 || inputDirection.y != 0)
        {
            if (moveCoroutine == null && inputDelayCoroutine == null)
            {
                inputDelayCoroutine = Wait(InputRepeatDelay);
                StartCoroutine(inputDelayCoroutine);

                moveCoroutine = Move(inputDirection);
                StartCoroutine(moveCoroutine);
            }
        }

        if (inputDirection == Vector2.zero)
        {
            if (inputDelayCoroutine != null)
            {
                StopCoroutine(inputDelayCoroutine);
                inputDelayCoroutine = null;
            }
        }
    }

    void GetMoveDirection()
    {
        inputDirection.x = Input.GetAxisRaw("Horizontal");
        inputDirection.y = Input.GetAxisRaw("Vertical");

        //prioritize y-axis if both direction.x and .y are changed
        if (Mathf.Abs(inputDirection.x) > Mathf.Abs(inputDirection.y))
            inputDirection.y = 0;
        else
            inputDirection.x = 0;
    }

    IEnumerator Wait(float amount)
    {
        yield return WaitForSeconds(amount);
        inputDelayCoroutine = null;
    }

    IEnumerator Move(Vector2 direction)
    {
        //invoke MoveAction once if either player can move
        foreach (var player in players)
        {
            if (!player.IsTouchingCollider(direction))
            {
                MoveAction?.Invoke();
                break;
            }
        }

        //start move coroutine for all players that can move
        foreach (var player in players)
        {
            if (!player.IsTouchingCollider(direction))
            {
                StartCoroutine(player.Move(direction));
            }
        }

        yield return WaitForSeconds(MoveDuration);

        moveCoroutine = null;
    }

    void OnPlayerEnterGoal(int playerCount)
    {
        if (playerCount == PlayerCount)
            enabled = false;
    }
}