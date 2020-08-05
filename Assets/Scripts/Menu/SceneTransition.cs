using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static CoroutineHelper;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] Material transitionMat;

    void Awake()
    {
        FadeSceneIn();
    }

    void FadeSceneIn()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeSceneOut(int nextSceneIndex)
    {
        StartCoroutine(FadeOut(nextSceneIndex));
    }

    IEnumerator FadeIn()
    {
        float currentLerpTime = 0;
        float totalLerpTime = 1;

        while (currentLerpTime < totalLerpTime)
        {
            yield return EndOfFrame;
            currentLerpTime += Time.deltaTime;

            transitionMat.SetFloat("_AnimationTime", Mathf.Lerp(0, totalLerpTime, currentLerpTime / totalLerpTime));
        }
    }

    IEnumerator FadeOut(int nextSceneIndex)
    {
        float currentLerpTime = 0;
        float totalLerpTime = 1;

        while (currentLerpTime < 1)
        {
            yield return EndOfFrame;
            currentLerpTime += Time.deltaTime;

            transitionMat.SetFloat("_AnimationTime", Mathf.Lerp(totalLerpTime, 0, currentLerpTime / totalLerpTime));
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}