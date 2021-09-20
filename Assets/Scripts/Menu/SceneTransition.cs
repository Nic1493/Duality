using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using static CoroutineHelper;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] Material transitionMat;

    void Awake()
    {
        StartCoroutine(Fade(0f, 1f));
    }

    public void FadeSceneOut(int nextSceneIndex)
    {
        StartCoroutine(FadeOut(nextSceneIndex));
    }

    IEnumerator Fade(float start, float end)
    {
        float currentLerpTime = 0f;

        while (currentLerpTime < 1f)
        {
            transitionMat.SetFloat("_AnimationTime", Mathf.Lerp(start, end, currentLerpTime));

            currentLerpTime += Time.deltaTime;
            yield return EndOfFrame;
        }
    }

    IEnumerator FadeOut(int nextSceneIndex)
    {
        yield return Fade(1f, 0f);
        SceneManager.LoadScene(nextSceneIndex);
    }
}