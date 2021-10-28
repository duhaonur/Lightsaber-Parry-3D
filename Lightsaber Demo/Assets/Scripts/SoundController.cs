using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource lightsaberSound;

    public void PlayAudio()
    {
        lightsaberSound.Play();
    }

}
