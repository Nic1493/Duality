using UnityEngine;
using UnityEngine.UI;

public class ClearMenu : Menu
{
    GameObject nextLevelButton;

    protected override void Awake()
    {
        base.Awake();

        FindObjectOfType<Goal>().levelClearedAction += OnLevelClear;
        nextLevelButton = GetComponentsInChildren<Button>()[0].gameObject;
    }
    
    void OnLevelClear()
    {
        Open(nextLevelButton);
    }
}
