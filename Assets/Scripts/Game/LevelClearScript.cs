using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelClearScript : MonoBehaviour
{
    private int playerCount = 0;
    public bool levelCleared = false;

    private UnityAction levelClearedAction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerCount >= 2)
        {
            levelCleared = true;
            Debug.Log("Both Players are inside");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        playerCount++;
        Debug.Log("Entered");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        playerCount--;
        Debug.Log("Exited");
    }
}
