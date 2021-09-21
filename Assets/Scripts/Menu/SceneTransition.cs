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

    private void FadeSceneOut(int nextSceneIndex)
    {
        StartCoroutine(FadeOut(nextSceneIndex));
    }

    public void OnNextLevelPressed()
    {
        FadeSceneOut(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnRetryPressed()
    {
        FadeSceneOut(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMainMenuPressed()
    {
        FadeSceneOut(0);
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