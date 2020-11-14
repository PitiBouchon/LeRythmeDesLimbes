using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Music", menuName = "Music")]
public class MusicObject : ScriptableObject
{
    public string musicName;
    public AudioClip mucic;
    [SerializeField]
    [Range(0, 1)]
    public float volume;
    public float tempo = 0.5f;
    public float offset = 0;

    

}
