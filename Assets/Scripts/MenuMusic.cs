using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{

    private AudioSource audioSource;

    public AudioClip music;

    [SerializeField]
    [Range(0, 1)]
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music;
        audioSource.volume = volume;
        audioSource.Play();
        DontDestroyOnLoad(gameObject);
    }

}
