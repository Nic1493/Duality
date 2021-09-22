using UnityEngine;
using UnityEngine.UI;

public class ClearMenu : Menu
{
    GameObject nextLevelButton;

    protected override void Awake()
    {
        base.Awake();

        nextLevelButton = GetComponentsInChildren<Button>()[0].gameObject;
        FindObjectOfType<Goal>().LevelClearedAction += OnLevelClear;
    }
    
    void OnLevelClear()
    {
        Open(nextLevelButton);
    }
}
