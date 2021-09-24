using UnityEngine;

public class Goal : MonoBehaviour
{
    Animator[] anims;

    int playersInGoal = 0;
    public event System.Action<int> PlayerInGoalAction;
    [SerializeField] IntObject levelClearCount;

    void Awake()
    {
        anims = GetComponentsInChildren<Animator>();
        PlayerInGoalAction += OnPlayerEnterGoal;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        playersInGoal++;
        PlayerInGoalAction?.Invoke(playersInGoal);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        playersInGoal--;
    }

    void OnPlayerEnterGoal(int playerCount)
    {
        if (playersInGoal == 2)
        {
            foreach (var anim in anims)
            {
                anim.enabled = false;
                levelClearCount.value = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            }
        }
    }
}