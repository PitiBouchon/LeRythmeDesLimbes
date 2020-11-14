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

    public int[] sentenceIntro = {0,0,0,0,0,0,0,0};
    public int[] sentence1 = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    public int[] sentence2 = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    public int[] transition1 = {0,0,0,0,0,0,0,0};
    public int[] sentence3 = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    public int[] sentence4 = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

}
