using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;
public class ConfigSound : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider musicSlider, sfxSlider, masterSlider;
    [SerializeField] TMP_Text _masterValueText, _musicValueText, _sfxValueText;

    [SerializeField] Animator animator;
    public void Start()
    {
        if(PlayerPrefs.HasKey("MasterVolume"))
        {
            LoadVolumen();
        }
        else
        {
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolumen();
        }
    }


    public void OnEnable()
    {
        animator.SetBool("IsActive", true);
    }

    public void SetMasterVolume()
    {
        float volumen = masterSlider.value;
        _mixer.SetFloat("MasterVolume", Mathf.Log10(volumen) * 20);
        _masterValueText.text = Mathf.RoundToInt(volumen * 100) + "%";
        PlayerPrefs.SetFloat("MasterVolume", volumen);
    }

    public void SetMusicVolume()
    {
        float volumen = musicSlider.value;
        _mixer.SetFloat("MusicVolume", Mathf.Log10(volumen) * 20);
        _musicValueText.text = Mathf.RoundToInt(volumen * 100) + "%";
        PlayerPrefs.SetFloat("MusicVolume", volumen);
    }

    public void SetSFXVolumen()
    {
        float volumen = sfxSlider.value;
        _mixer.SetFloat("SoundFXVolume", Mathf.Log10(volumen) * 20);
        _sfxValueText.text = Mathf.RoundToInt(volumen * 100) + "%";
        PlayerPrefs.SetFloat("SoundFXVolume", volumen);
    }

    public void LoadVolumen()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SoundFXVolume");

        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolumen();
    }

    public void PlayAnimationGoToShop()
    {
        animator.SetBool("IsActive", false);
    }


}
