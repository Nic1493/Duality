using UnityEngine;

public class Goal : MonoBehaviour
{
    Animator[] anims;

    int playerCount = 0;
    bool levelCleared = false;
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
        {
            LevelClearedAction?.Invoke();
            print(playerCount);
        }
        
        if (playerCount == 1 && false)
        {
            OnePlayerEnterGoal();
            print(playerCount);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        playerCount--;
    }

    void OnePlayerEnterGoal()
    {
        FindObjectOfType<AudioManager>().Play("OneInGoal");
    }

    void OnLevelClear()
    {
        levelCleared = true;
        foreach (var anim in anims)
        {
            anim.enabled = false;
            FindObjectOfType<AudioManager>().Play("TwoInGoal");
        }
    }
}