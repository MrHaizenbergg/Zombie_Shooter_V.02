using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _slider;
    [SerializeField] private Dropdown _dropdown;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
            LoadVolume();
        else
            SetMusicVolume();

        //if (PlayerPrefs.HasKey("CurrentQuality"))
        //    LoadQuality();
        //else
        //    SetQuality();
    }

    public void SetQuality()
    {
        int quality = _dropdown.value;
        QualitySettings.SetQualityLevel(quality);
        PlayerPrefs.SetInt("CurrentQuality", quality);
    }

    //private void LoadQuality()
    //{
    //    _dropdown.value = PlayerPrefs.GetInt("CurrentQuality");

    //    SetQuality();
    //}

    public void SetMusicVolume()
    {
        float volume = _slider.value;
        _audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    private void LoadVolume()
    {
        _slider.value = PlayerPrefs.GetFloat("MusicVolume");

        SetMusicVolume();
    }
}
