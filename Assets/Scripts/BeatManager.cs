using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{

    List<GameObject> beats = new List<GameObject>();
    public GameObject end_r;
    public GameObject end_w;
    public GameObject beat;
    public GameObject blank;

    private int pulseCount = 0;

    private List<int> actualSentence = new List<int>();

    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private int distance = 20;
    [SerializeField]
    private int maxBeats = 20;

    private void Start()
    {
        loadSentence(new int[80] { 1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0,1,0,0,1,1,0,0,0});
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log(pulseCount);
            UpdateBeat(actualSentence[0]);
            actualSentence.RemoveAt(0);
            printActualSentence();
        }
    }

    private void printActualSentence()
    {
        for(int i = 0; i < actualSentence.Count; i++)
        {
            Debug.Log(actualSentence);
        }
    }

    public void loadSentence(int[] sentence)
    {
        beats.Clear();
        for(int i = 0; i < sentence.Length; i++)
        {
            actualSentence.Add(sentence[i]);
            if (sentence[i] == 1) beats.Add(Instantiate(beat));
            else beats.Add(Instantiate(blank));
            beats[i].transform.position = new Vector3(357+maxBeats*2*speed - i * distance, 50, 10);
            beats[i].transform.localScale += new Vector3(29, 29, 1);
        }
    }

    public void UpdateBeat(int actualBeat)
    {
        if (actualBeat == 0)
        {
            if (beats.Count > maxBeats - 1)
            {
                end_r.SetActive(false);
                end_w.SetActive(true);
            }
        }
        else if (actualBeat == 1)
        {
            if (beats.Count > maxBeats - 1)
            {
                end_r.SetActive(true);
                end_w.SetActive(false);
            }
        }
        //if (beats.Count > maxBeats)
        //{
        //    Destroy(beats[0]);
        //    beats.RemoveAt(0);
        //}
        for (int i = 0; i < beats.Count; i++)
        {
            beats[i].transform.position = Vector3.MoveTowards(beats[i].transform.position, new Vector3(beats[i].transform.position.x+distance, beats[i].transform.position.y, beats[i].transform.position.z), speed);
        }
    }
}
