using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", -(80-40*Mathf.Log10(volume)));
    }
}
