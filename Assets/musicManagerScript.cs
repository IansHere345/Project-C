using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class musicManagerScript : MonoBehaviour
{
    private AudioSource musicSource;

    [SerializeField] private string musicKey = "MenuMusicMuted";

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        musicSource.mute = PlayerPrefs.GetInt(musicKey, 0) == 1;
    }
}