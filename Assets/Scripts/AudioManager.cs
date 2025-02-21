using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
	AudioSource test;

    private void Start()
    {
        test = GetComponent<AudioSource>();
    }

    public void PlaySound()
	{
        if (!test.isPlaying)
        {
            test.Play();
        }
	}
}
