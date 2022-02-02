using System.Collections;
using UnityEngine;
using TMPro;
using static CoroutineHelper;

public class MoveCounter : MonoBehaviour
{
    TextMeshProUGUI moveCounterText;

    [SerializeField] IntObject moveCounter;
    [SerializeField] AnimationCurve moveCounterInterpolation;

    void Awake()
    {
        moveCounterText = GetComponent<TextMeshProUGUI>();

        FindObjectOfType<PlayerController>().MoveAction += OnPlayerMove;
        FindObjectOfType<Goal>().PlayerInGoalAction += OnPlayerEnterGoal;
    }

    void Start()
    {
        moveCounter.value = 0;
    }

    void OnPlayerMove()
    {
        moveCounter.value++;
    }

    void OnPlayerEnterGoal(int playerCount)
    {
        if (playerCount == 2)
            StartCoroutine(LerpMoveCount());
    }

    IEnumerator LerpMoveCount()
    {
        float currentLerpTime = 0f, totalLerpTime = 1f;

        int currentValue = 0, endValue = moveCounter.value;

        while (currentValue != endValue)
        {
            float lerpProgress = moveCounterInterpolation.Evaluate(currentLerpTime / totalLerpTime);
            int lerpedMoveCounter = (int)Mathf.Lerp(currentValue, endValue, lerpProgress);

            moveCounterText.text = lerpedMoveCounter.ToString();

            yield return EndOfFrame;
            currentLerpTime += Time.deltaTime;
        }
    }
}