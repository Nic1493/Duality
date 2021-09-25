using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClearMenu : Menu
{
    GameObject nextLevelButton;
    SceneTransition sceneTransition;

    protected override void Awake()
    {
        base.Awake();

        nextLevelButton = GetComponentsInChildren<Button>()[0].gameObject;
        FindObjectOfType<Goal>().PlayerInGoalAction += OnPlayerEnterGoal;

        sceneTransition = FindObjectOfType<SceneTransition>();
    }
    
    void OnPlayerEnterGoal(int playerCount)
    {
        if (playerCount == 2)
            Open(nextLevelButton);
    }

    #region Button Functions

    public void OnNextLevelPressed()
    {
        StartCoroutine(sceneTransition.FadeOutToNextScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void OnRetryPressed()
    {
        StartCoroutine(sceneTransition.FadeOutToNextScene(SceneManager.GetActiveScene().buildIndex));
    }

    public void OnMainMenuPressed()
    {
        StartCoroutine(sceneTransition.FadeOutToNextScene(0));
    }

    #endregion
}
