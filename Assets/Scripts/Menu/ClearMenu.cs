using UnityEngine.SceneManagement;

public class ClearMenu : Menu
{
    protected override void Awake()
    {
        base.Awake();
        FindObjectOfType<Goal>().levelClearedAction += OnLevelClear;
    }
    
    void OnLevelClear()
    {
        OpenMenu(thisMenu);
    }

    public void OnSelectRetry()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnSelectNextLevel()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
