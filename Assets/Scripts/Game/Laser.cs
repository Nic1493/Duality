using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        print("hit " + other.name);
    }
}