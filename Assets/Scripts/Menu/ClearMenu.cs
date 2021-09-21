using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
