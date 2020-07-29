using System.Collections;
using UnityEngine;
using static CoroutineHelper;

public class PlayerController : MonoBehaviour
{
    IEnumerator moveCoroutine;
    Vector2 moveDirection;
    Vector2 moveDistance;
    const float MoveDuration = 0.1f;

    IEnumerator inputDelayCoroutine;
    const float InputRepeatDelay = 0.25f;

    void Awake()
    {
        //set moveDistance to always equal sprite's dimensions
        moveDistance = GetComponent<SpriteRenderer>().bounds.size;
    }

    void Update()
    {
        UpdateMoveDirection();

        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            if (moveCoroutine == null && inputDelayCoroutine == null)
            {
                inputDelayCoroutine = Wait(InputRepeatDelay);
                StartCoroutine(inputDelayCoroutine);

                moveCoroutine = Move(moveDirection);
                StartCoroutine(moveCoroutine);
            }
        }
    }

    void UpdateMoveDirection()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        //prioritize y-axis if both direction.x and .y are changed
        if (Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y)) moveDirection.y = 0;
        else moveDirection.x = 0;
    }

    IEnumerator Wait(float amount)
    {
        yield return WaitForSeconds(amount);
        inputDelayCoroutine = null;
    }

    IEnumerator Move(Vector2 direction)
    {
        float currentLerpTime = 0;
        Vector2 startPos = transform.position;
        Vector2 endPos = (Vector2)transform.position + (moveDistance * direction);

        while (currentLerpTime < MoveDuration)
        {
            yield return EndOfFrame;
            currentLerpTime += Time.deltaTime;

            transform.position = Vector2.Lerp(startPos, endPos, currentLerpTime / MoveDuration);
        }

        moveCoroutine = null;
    }
}