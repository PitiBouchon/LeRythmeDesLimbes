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
    private int[] sentenceIntro = {0,0,0,0,0,0,0};
    private int[] sentence1 = {1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
    private int[] sentence2 = {1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
    private int[] sentence3 = {1,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0};
    private int[] transition1 = {0,0,0,0,0,0,0,0};
    private int[] sentence4 = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

    [SerializeField] private float pulse;

    private int[] currentSentence;

    private float currentSentenceLength;

    private int[] nextSentence;

    private int progression = 0; // A MODIFIER LORSQUE UNE AME GENTILLE SURVIT JUSQU AU BOUT

    private bool isPlaying = true;

    void Start()
    {
        currentSentence = sentenceIntro;
        currentSentenceLength = currentSentence.GetLength(0);
        nextSentence = sentence1;

        GetComponent<AudioSource>().clip = musicBackground.mucic;
        GetComponent<AudioSource>().volume = musicBackground.volume;
        pulse = musicBackground.tempo/2;
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().loop = true;
        StartCoroutine(UpdateRythm());
    }

    private IEnumerator UpdateRythm()  // On fonctionne avec une coroutine pour l'instant il faudra peut-être utiliser Invoke Reapeating et gérer les asynchronismes
    {
        while (isPlaying)
        {
            for (var i = 0 ; i<currentSentenceLength ; i++)
            {
                yield return new WaitForSecondsRealtime(pulse);
                if (currentSentence[i] == 1){
                    monsterManager.updateMonsters();
                    //UPDATE ALLIES
                    //UPDATE TOWERS
                }
                
                if (i == 0)
                {
                    monsterManager.addMonster();
                }
            }
            currentSentence = nextSentence;
            currentSentenceLength = currentSentence.GetLength(0);
            nextSentence = sentence1;

        }
    }

}
