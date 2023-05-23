using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    // Play SE (Sound Effect) 
    public void PlaySE(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void StopPlayingSE()
    {
        audioSource.Stop();
    }


}
