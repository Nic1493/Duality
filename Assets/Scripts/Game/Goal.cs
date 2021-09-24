using UnityEngine;

public class Goal : MonoBehaviour
{
    Animator[] anims;

    int playersInGoal = 0;
    public event System.Action LevelClearedAction;
    [SerializeField] IntObject levelClearCount;

    void Awake()
    {
        anims = GetComponentsInChildren<Animator>();
        LevelClearedAction += OnLevelClear;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        playersInGoal++;

        if (playersInGoal == 2)
        {
            LevelClearedAction?.Invoke();
            print(playersInGoal);
        }
        
        if (playersInGoal == 1 && false)
        {
            OnePlayerEnterGoal();
            print(playersInGoal);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        playersInGoal--;
    }

    void OnePlayerEnterGoal()
    {
        FindObjectOfType<AudioManager>().Play("OneInGoal");
    }

    void OnLevelClear()
    {
        foreach (var anim in anims)
        {
            anim.enabled = false;
            levelClearCount.value = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            FindObjectOfType<AudioManager>().Play("TwoInGoal");
        }
    }
}