using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{

    private AudioMixer audioMixer;
    public MusicObject leitmotiv;
    public MusicObject level1Percu;
    public MusicObject level1Part1;
    public MusicObject level1Part2;
    public MusicObject level1Part3;
    public MusicObject level1Part4;

    private AudioSource audioSource;


    public List<MusicObject> level1;
    public List<MusicObject> currentLevel;
    public int currentPart;
    public int currentLevelLength;
    void Start()
    {
        leitmotiv.tempochart = new int[16]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        level1Percu.tempochart = new int[5]{0,0,0,0,0};
        level1Part1.tempochart = new int[16]{1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
        level1Part2.tempochart = new int[16]{1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
        level1Part3.tempochart = new int[16]{1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
        level1Part4.tempochart = new int[16]{1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};

        audioSource = GetComponent<AudioSource>();
        level1.Add(level1Percu);
        level1.Add(level1Part1);
        level1.Add(level1Part2);
        level1.Add(level1Part3);
        level1.Add(level1Part4);
    }


    public int[] getFirstSentence(int level)
    {
        if (level == 1)
        { 
            currentLevel = level1;
            currentPart = 0;
            currentLevelLength = level1.Count;
            audioSource.clip = level1[currentPart].mucic;
            audioSource.volume = level1[currentPart].volume;
            audioSource.Play();
            return level1[currentPart].tempochart;
        }
        
        return leitmotiv.tempochart;
        
    }

    public int[] getNextSentence(bool next)
    {
        if (next)
        {
            currentPart++;
            audioSource.clip = level1[currentPart].mucic;
            audioSource.volume = level1[currentPart].volume;
            audioSource.Play();
        }
        else
        {
            audioSource.clip = level1[currentPart].mucic;
            audioSource.volume = level1[currentPart].volume;
            audioSource.Play();
        }

        return level1[currentPart].tempochart;
    }
}