using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Music", menuName = "Music")]
public class MusicObject : ScriptableObject
{
    public string musicName;
    public AudioClip mucic;
    public float tempo;
    public float offset = 0;
}
