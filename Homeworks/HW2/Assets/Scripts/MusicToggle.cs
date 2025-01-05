using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicToggle : MonoBehaviour
{
    [Header("Audio Source")]
    public AudioSource backgroundMusic; // Reference to the background music AudioSource

    private bool isMusicOn = true; // Tracks if music is currently playing

    void Start()
    {
        if (backgroundMusic == null)
        {
            return;
        }

        // Ensure music starts playing
        backgroundMusic.Play();
        isMusicOn = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMusic();
        }
    }

    private void ToggleMusic()
    {
        isMusicOn = !isMusicOn;

        if (isMusicOn)
        {
            backgroundMusic.Play();
        }
        else
        {
            backgroundMusic.Pause();
        }
    }
}
