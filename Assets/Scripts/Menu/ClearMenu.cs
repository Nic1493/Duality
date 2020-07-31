using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearMenu : Menu
{
    // Start is called before the first frame update
    void Start()
    {
        thisMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            OpenMenu(thisMenu);
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("GameObject1 collided with " + col.name);
    }
}
