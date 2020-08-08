using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        Shoot(GetDistanceToWall());
    }

    float GetDistanceToWall()
    {
        Vector2 rayOrigin = transform.position;
        Vector2 rayDirection = transform.up;

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, rayDirection);
        if (hit.collider != null)
        {
            return (hit.point - rayOrigin).magnitude;
        }

        return 0;
    }

    void Shoot(float distance)
    {
        sr.size = new Vector2(sr.size.x, distance);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print("hit " + other.name);
    }
}