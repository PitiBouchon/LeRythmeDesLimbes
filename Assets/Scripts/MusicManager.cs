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
    public MusicObject level1Fin;

    public MusicObject level2Percu;
    public MusicObject level2Part1;
    public MusicObject level2Part2;
    public MusicObject level2Part3;
    public MusicObject level2Part4;
    public MusicObject level2Fin;

    private AudioSource audioSource;


    private List<MusicObject> level1 = new List<MusicObject>();
    private List<MusicObject> level2 = new List<MusicObject>();
    private List<MusicObject> currentLevel;
    private int currentPart = 0;
    private int currentLevelLength = 0;
    void Awake()
    {
        leitmotiv.tempochart = new int[32]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        level1Percu.tempochart = new int[16]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        level1Part1.tempochart = new int[64]{1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
        level1Part2.tempochart = new int[64]{1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
        level1Part3.tempochart = new int[64]{1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
        level1Part4.tempochart = new int[72]{1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
        level1Fin.tempochart = new int[8]{0,0,0,0,0,0,0,0};
        level2Percu.tempochart =  new int[16]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        level2Part1.tempochart = new int[64]{1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
        level2Part2.tempochart = new int[96]{1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0};
        level2Part3.tempochart = new int[72]{1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0,1,0,0,0,1,0,1,0};
        level2Part4.tempochart = new int[80]{1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0};
        level2Fin.tempochart = new int[8]{0,0,0,0,0,0,0,0};

        audioSource = GetComponent<AudioSource>();
        level1.Add(level1Percu);
        level1.Add(level1Part1);
        level1.Add(level1Part2);
        level1.Add(level1Part3);
        level1.Add(level1Part4);
        level1.Add(level1Fin);

        level2.Add(level2Percu);
        level2.Add(level2Part1);
        level2.Add(level2Part2);
        level2.Add(level2Part3);
        level2.Add(level2Part4);
        level2.Add(level2Fin);
    }


    public int[] getFirstSentence(int level)
    {
        if (level == 1)
        { 
            currentLevel = new List<MusicObject>(level1);
            currentPart = 0;
            currentLevelLength = currentLevel.Count;
            audioSource.clip = currentLevel[currentPart].mucic;
            audioSource.volume = currentLevel[currentPart].volume;
            audioSource.Play();
            return currentLevel[currentPart].tempochart;
        }

        if (level == 2)
        { 
            currentLevel = new List<MusicObject>(level2);
            currentPart = 0;
            currentLevelLength = currentLevel.Count;
            audioSource.clip = currentLevel[currentPart].mucic;
            audioSource.volume = currentLevel[currentPart].volume;
            audioSource.Play();
            return currentLevel[currentPart].tempochart;
        }
        
        return leitmotiv.tempochart;
        
    }

    public int[] getNextSentence(bool next)
    {
        if (next)
        {
            currentPart++;
            if (currentPart >= currentLevel.Count)
            {
                currentPart = 0;
            }
            audioSource.clip = currentLevel[currentPart].mucic;
            audioSource.volume = currentLevel[currentPart].volume;
            audioSource.Play();
        }
        else
        {
            audioSource.clip = currentLevel[currentPart].mucic;
            audioSource.volume = currentLevel[currentPart].volume;
            audioSource.Play();
        }

        return currentLevel[currentPart].tempochart;
    }
}