using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectMenu : Menu
{
    [SerializeField] Button backButton;

    Button[] levelSelectButtons;
    [SerializeField] IntObject levelClearCount;

    protected override void Awake()
    {
        base.Awake();

        levelSelectButtons = GetComponentsInChildren<Button>();
        Array.Resize(ref levelSelectButtons, 16);
    }

    void OnEnable()
    {
        for (int i = 0; i < levelSelectButtons.Length; i++)
        {
            levelSelectButtons[i].enabled = i <= Mathf.Max(1, levelClearCount.value);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            backButton.OnPointerClick(eventData);
    }
}