using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public MonsterManager monsterManager;
    public MusicObject musicBackground;
    private float timerTempo;
    private int timerCount;

    void Start()
    {
        GetComponent<AudioSource>().clip = musicBackground.mucic;
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
