using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveCounter : MonoBehaviour
{
    [SerializeField]
    PlayerController whitePlayerController;

    [SerializeField]
    PlayerController blackPlayerController;

    Text movementCounterText;

    // Start is called before the first frame update
    void Start()
    {
        movementCounterText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    void UpdateText()
    {
        if (whitePlayerController.moveCount <= blackPlayerController.moveCount)
        {
            movementCounterText.text = "Move Counter: " + blackPlayerController.moveCount;
        }
        else
        {
            movementCounterText.text = "Move Counter: " + whitePlayerController.moveCount;
        }
    }
}