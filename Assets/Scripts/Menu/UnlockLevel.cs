using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnlockLevel : MonoBehaviour
{
    [SerializeField] IntObject levelClearCount;
    [SerializeField] Button[] buttons;
    int lastLevelUnlocked = 0;

    // Update is called once per frame
    void Update()
    {
        EnableLevelButton();
    }

    void EnableLevelButton()
    {
        for (int i = 0; levelClearCount.value > i; i++)
        {
            buttons[].enabled();
        }
    }
}
