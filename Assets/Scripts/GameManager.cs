using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [SerializeField] private float pulse;

    private int[] currentSentence;

    private float currentSentenceLength;

    private int[] nextSentence;

    private int progression = 0; // A MODIFIER LORSQUE UNE AME GENTILLE SURVIT JUSQU AU BOUT

    private bool isPlaying = true;

    private int[] sentenceIntro = {0,0,0,0,0,0,0,0};
    private int[] sentence1 = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    private int[] sentence2 = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    private int[] transition1 = {0,0,0,0,0,0,0,0};
    private int[] sentence3 = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
    private int[] sentence4 = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

    void Start()
    {
        currentSentence = sentenceIntro;
        currentSentenceLength = currentSentence.GetLength(0);
        StartCoroutine(UpdateRythm());
    }

    private IEnumerator UpdateRythm()
    {
        while (isPlaying)
        {
            for (var i = 0 ; i<currentSentenceLength ; i++)
            {
                yield return new WaitForSeconds(pulse);
                if (currentSentence[i] == 1){
                    //UPDATE MONSTERS
                    //UPDATE ALLIES
                }
                //UPDATE TOWERS
            }
            currentSentence = nextSentence;
            
            //UPDATE NEXT SENTENCE KNOWING PROGRESSION

        }
    }


}
