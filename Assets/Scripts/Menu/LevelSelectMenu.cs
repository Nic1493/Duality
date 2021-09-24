using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : Menu
{
    [SerializeField] Button backButton;

    [SerializeField] IntObject levelClearCount;
    [SerializeField] Button[] buttons;

    void Start()
    {
        EnableLevelButton();
    }


    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            backButton.OnPointerClick(eventData);        
    }

    void EnableLevelButton()
    {
        for (int i = 0; i <= levelClearCount.value; i++)
        {
            buttons[i].GetComponent<Button>().enabled = true;
        }
    }
}