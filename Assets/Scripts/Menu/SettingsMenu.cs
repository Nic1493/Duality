using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : Menu
{
    [SerializeField] PlayerSettings playerSettings;
    [SerializeField] Button backButton;
    [SerializeField] Slider volumeSlider;
    [SerializeField] TextMeshProUGUI volumeText;

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
        volumeText.text = playerSettings.Volume.ToString();
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