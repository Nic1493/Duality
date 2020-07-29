using System.Collections;
using UnityEngine;
using static CoroutineHelper;

public class PlayerController : MonoBehaviour
{
    IEnumerator moveCoroutine;
    Vector2 moveDistance;
    const float MoveDuration = 0.1f;

    void Awake()
    {
        //set moveDistance to always equal sprite's dimensions
        moveDistance = GetComponent<SpriteRenderer>().bounds.size;
    }

    void Update()
    {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            if (moveCoroutine == null)
            {
                moveCoroutine = Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
                StartCoroutine(moveCoroutine);
            }
        }
    }

    IEnumerator Move(Vector2 direction)
    {
        //prioritize y-axis if both direction.x and .y are changed
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) direction.y = 0;
        else direction.x = 0;

        direction.Normalize();

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