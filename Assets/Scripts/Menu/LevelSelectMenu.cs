using UnityEngine;

public class LevelSelectMenu : Menu
{
    [SerializeField] Canvas mainMenu;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SwitchMenu(mainMenu);
        }
    }
}