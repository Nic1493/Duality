using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectMenu : Menu
{
    [SerializeField] Canvas mainMenu;

    public void OnSelectLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex + 1);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SwitchMenu(mainMenu);
        }
    }
}