using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Menu
{
    [SerializeField] PlayerSettings playerSettings;
    [SerializeField] Button backButton;
    [SerializeField] Slider volumeSlider;

    protected override void Awake()
    {
        base.Awake();
        InitUIObjects();
    }

    void InitUIObjects()
    {
        UpdateVolumeSlider();
    }

    void UpdateVolumeSlider()
    {
        volumeSlider.value = playerSettings.Volume;
    }

    public void OnChangeVolume()
    {
        playerSettings.Volume = (int)volumeSlider.value;
        UpdateVolumeSlider();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            backButton.OnPointerClick(eventData);
    }
}