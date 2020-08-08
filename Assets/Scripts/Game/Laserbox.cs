using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Laserbox : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] List<Vector2> laserDirections = new List<Vector2>();

    void Start()
    {
        foreach (Vector2 dir in laserDirections)
        {
            Vector3.Normalize(dir);

            if (dir != Vector2.zero)
            {
                Quaternion spawnRotation = Quaternion.Euler(0, 0, Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg);
                GameObject newLaser = Instantiate(laser, transform.position, spawnRotation) as GameObject;
                newLaser.transform.parent = transform;
            }
        }
    }
}