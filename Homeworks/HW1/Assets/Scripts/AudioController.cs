using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    private AudioSource audioSource;
    private bool isMuted = false; // Track mute state

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // Check if audio source is not null and play audio
        if (audioSource != null)
        {
            audioSource.Play(); // Play the audio on start
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for 'M' key press to toggle mute/unmute
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMuted = !isMuted; // Toggle the mute state

            audioSource.mute = isMuted; // Mute or unmute based on the state
        }
    }
}
