using UnityEngine;

public class Laserbox : MonoBehaviour
{
    [SerializeField] GameObject laser;
    [SerializeField] Vector2[] laserDirections;

    void Start()
    {
        foreach (Vector2 dir in laserDirections)
        {
            if (dir != Vector2.zero)
            {
                Shoot(dir.normalized, GetDistanceToWall(dir.normalized));
            }
        }
    }

    float GetDistanceToWall(Vector2 direction)
    {
        Vector2 rayOrigin = transform.position;

        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, direction);
        if (hit.collider != null)
        {
            return (hit.point - rayOrigin).magnitude;
        }

        return 0;
    }

    void Shoot(Vector2 direction, float distance)
    {
        Quaternion spawnRotation = Quaternion.Euler(0, 0, Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg);
        GameObject newLaser = Instantiate(laser, transform.position, spawnRotation) as GameObject;
        newLaser.transform.parent = transform;

        SpriteRenderer sr = newLaser.GetComponent<SpriteRenderer>();
        sr.size = new Vector2(sr.size.x, distance);
    }
}