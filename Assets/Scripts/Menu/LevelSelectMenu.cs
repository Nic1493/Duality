using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : Menu
{
    [SerializeField] Button backButton;

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            backButton.OnPointerClick(eventData);        
    }
}