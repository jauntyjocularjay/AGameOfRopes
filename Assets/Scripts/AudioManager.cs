using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	AudioSource audioPlayer;

    private void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
    }
    public void PlaySound(AudioResource resource)
	{
        if (!audioPlayer.isPlaying)
        {
            audioPlayer.resource = resource;
            audioPlayer.Play();
        }
	}
}
