using UnityEngine;

public class Goal : MonoBehaviour
{
    Animator[] anims;

    int playerCount = 0;
    public event System.Action LevelClearedAction;

    void Awake()
    {
        anims = GetComponentsInChildren<Animator>();
        LevelClearedAction += OnLevelClear;
    }

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

    void OnLevelClear()
    {
        foreach (var anim in anims)
        {
            anim.enabled = false;
        }
    }
}