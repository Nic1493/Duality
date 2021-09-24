using UnityEngine;
using UnityEngine.UI;

public class ClearMenu : Menu
{
    GameObject nextLevelButton;

    protected override void Awake()
    {
        base.Awake();

        nextLevelButton = GetComponentsInChildren<Button>()[0].gameObject;
        FindObjectOfType<Goal>().PlayerInGoalAction += OnPlayerEnterGoal;
    }
    
    void OnPlayerEnterGoal(int playerCount)
    {
        if (playerCount == 2)
            Open(nextLevelButton);
    }
}
