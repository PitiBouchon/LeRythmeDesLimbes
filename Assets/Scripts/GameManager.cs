using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // Monsters
    public MonsterManager monsterManager;
    public TurretManager turretManager;

    // Music
    private AudioMixer audioMixer;
    public MusicManager musicManager;

    [SerializeField] private float pulse = 0.25f;

    private int[] currentSentence;

    private float currentSentenceLength;

    private int[] nextSentence;

    public int progression = 0;

    private bool isPlaying = true;

    public int maxHP = 20;
    public Text HPText;

    public int goNext;


    void Start()
    {
        currentSentence = musicManager.getFirstSentence(PlayerPrefs.GetInt("levelPlayed"));
        currentSentenceLength = currentSentence.GetLength(0);
        StartCoroutine(UpdateRythm());
    }

    public void loseLife()
    {
        maxHP-=1;
        HPText.text = maxHP.ToString();
        if (maxHP <=0) {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private IEnumerator UpdateRythm()  // On fonctionne avec une coroutine pour l'instant il faudra peut-être utiliser Invoke Reapeating et gérer les asynchronismes
    {
        while (isPlaying)
        {
            for (var i = 0 ; i<currentSentenceLength ; i++)
            {
                if (currentSentence[i] == 1){
                    monsterManager.updateMonsters();
                    //UPDATE ALLIES
                    turretManager.TempoUpdate();
                    if (progression == 10)
                    {
                        SceneManager.LoadScene("MainMenu");
                    }
                }
                

                yield return new WaitForSecondsRealtime(pulse);
            }
            
            currentSentence = musicManager.getNextSentence(true);
            
            currentSentenceLength = currentSentence.GetLength(0);
        }
    }

}
