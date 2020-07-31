using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : Menu
{
    [SerializeField] Canvas mainMenu;

    [Space]

    [SerializeField] Slider volumeSlider;
    [SerializeField] TextMeshProUGUI volumeText;

    [Space]

    [SerializeField] Slider repeatDelaySlider;
    [SerializeField] TextMeshProUGUI repeatDelayText;

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
        volumeText.text = volumeSlider.value.ToString();
    }

    void UpdateRepeatDelaySlider()
    {
        repeatDelayText.text = repeatDelaySlider.value.ToString();
    }

    public void OnChangeVolume()
    {
        UpdateVolumeSlider();
    }

    public void OnChangeRepeatDelay()
    {
        UpdateRepeatDelaySlider();
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SwitchMenu(mainMenu);
        }
    }
}