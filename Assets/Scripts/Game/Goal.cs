using UnityEngine;

public class Goal : MonoBehaviour
{
    int playerCount = 0;
    public event System.Action levelClearedAction;

    void OnTriggerEnter2D(Collider2D col)
    {
        playerCount++;
        Debug.Log("Entered");

        if (playerCount == 2)
        {
            levelClearedAction?.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        playerCount--;
        Debug.Log("Exited");
    }
}