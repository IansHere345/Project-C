using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class musicToggleManager : MonoBehaviour
{
    [SerializeField] private string musicKey = "MenuMusicMuted";
    [SerializeField] RawImage musicOnImage;
    [SerializeField] RawImage musicOffImage;
    private bool muted = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        muted = PlayerPrefs.GetInt(musicKey, 0) == 1;
        UpdateButtonIcon();
    }

    public void onButtonPress()
    {
        muted = !muted;
        // This is added so music properly turns on and off.
        PlayerPrefs.SetInt(musicKey, muted ? 1 : 0);
        PlayerPrefs.Save();
        // This makes sure the users choice is saved between scenes
        UpdateButtonIcon();
    }
    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            musicOnImage.enabled = true;
            musicOffImage.enabled = false;
        }
        else
        {
            musicOnImage.enabled = false;
            musicOffImage.enabled = true;
        }
    }
}
//Source Used: https://www.youtube.com/watch?v=AFcHsKd_aMo&t=255s

