using UnityEngine;

public class MainMenu : Menu
{
    protected override void Awake()
    {
        base.Awake();
        FileHandler.LoadSettings();
    }

    public void OnSelectQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}