using UnityEngine;

public class HUD : MonoBehaviour
{
    void Awake()
    {
        FindObjectOfType<Goal>().PlayerInGoalAction += OnPlayerEnterGoal;
    }

    void OnPlayerEnterGoal(int playerCount)
    {
        if (playerCount == 2)
            enabled = false;
    }
}