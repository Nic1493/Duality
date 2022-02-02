using System.Collections;
using UnityEngine;
using static CoroutineHelper;

public class Player : MonoBehaviour
{
    Vector2 spriteSize;
    float moveDistance;
    const float MoveDuration = 0.1f;

    void Awake()
    {
        spriteSize = GetComponent<SpriteRenderer>().bounds.size;
        moveDistance = spriteSize.x;
    }

    public bool IsTouchingCollider(Vector2 checkDirection)
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position, spriteSize / 2f, 0f, checkDirection, moveDistance);
        return hit.collider != null;
    }

    public IEnumerator Move(Vector2 moveDirection)
    {
        float currentLerpTime = 0;
        Vector2 startPos = transform.position;
        Vector3 endPos = (Vector2)transform.position + (moveDirection * moveDistance);

        while (transform.position != endPos)
        {
            transform.position = Vector2.Lerp(startPos, endPos, currentLerpTime / MoveDuration);

            currentLerpTime += Time.deltaTime;
            yield return EndOfFrame;
        }
    }
}