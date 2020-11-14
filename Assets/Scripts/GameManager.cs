using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    // Monsters
    public MonsterManager monsterManager;

    // Music
    public MusicObject musicBackground;
    private AudioMixer audioMixer;

    // Timer
    private float timerTempo;
    private int timerCount;

    void Start()
    {
        GetComponent<AudioSource>().clip = musicBackground.mucic;
        GetComponent<AudioSource>().volume = musicBackground.volume;
        timerTempo = musicBackground.offset;
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (timerTempo < musicBackground.tempo)
        {
            timerTempo += Time.deltaTime;
        }
        else
        {
            timerTempo = 0;
            timerCount += 1;
            tempoUpdate();
        }
    }

    void tempoUpdate()
    {
        Debug.Log("Update everything");
        monsterManager.updateMonsters();

        // POUR TESTER LE SPAWN DE MONSTRES
        if (timerCount % 3 == 0)
        {
            monsterManager.addMonster();
        }
    }
}
