using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Menu
{
    [SerializeField] Button backButton;

    [Space]

    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider repeatDelaySlider;

    protected override void Awake()
    {
        base.Awake();
        InitSliders();
    }

    void InitSliders()
    {
        UpdateVolumeSlider();
        UpdateRepeatDelaySlider();
    }

    void UpdateVolumeSlider()
    {
        volumeSlider.value = PlayerSettings.Instance.volume;
    }

    void UpdateRepeatDelaySlider()
    {
        repeatDelaySlider.value = PlayerSettings.Instance.repeatDelay;
    }

    public void OnChangeVolume()
    {
        PlayerSettings.Instance.volume = (int)volumeSlider.value;
        UpdateVolumeSlider();
    }

    public void OnChangeRepeatDelay()
    {
        PlayerSettings.Instance.repeatDelay = repeatDelaySlider.value;
        UpdateRepeatDelaySlider();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
            backButton.OnPointerClick(eventData);
    }
}