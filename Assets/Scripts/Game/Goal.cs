using UnityEngine;

public class Goal : MonoBehaviour
{
    int playerCount = 0;
    public event System.Action LevelClearedAction;

    void OnTriggerEnter2D(Collider2D col)
    {
        playerCount++;

        if (playerCount == 2)
            LevelClearedAction?.Invoke();
    }

    void OnTriggerExit2D(Collider2D col)
    {
        playerCount--;
    }
}