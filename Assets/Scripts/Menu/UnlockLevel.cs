using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnlockLevel : MonoBehaviour
{
    [SerializeField] IntObject levelClearCount;
    [SerializeField] Button[] buttons;
    int lastLevelUnlocked = 0;

    void Start()
    {
        EnableLevelButton();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnableLevelButton()
    {
        for (int i = 0; i <= levelClearCount.value; i++)
        {
            buttons[i].GetComponent<Button>().enabled = true;
        }
    }
}