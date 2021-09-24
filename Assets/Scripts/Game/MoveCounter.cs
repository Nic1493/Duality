using UnityEngine;
using TMPro;

public class MoveCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moveCounterText;
    [SerializeField] IntObject moveCounter;

    void Awake()
    {
        FindObjectOfType<PlayerController>().MoveAction += OnPlayerMove;
    }

    void Start()
    {
        moveCounter.value = 0;

        // just in case moveCounter.text is not initialized to "0"
        UpdateText();
    }

    void OnPlayerMove()
    {
        moveCounter.value++;
        UpdateText();
    }

    void UpdateText()
    {
        moveCounterText.text = moveCounter.value.ToString();
    }
}