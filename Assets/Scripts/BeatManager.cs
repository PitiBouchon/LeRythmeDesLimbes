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

    private List<int> actualSentence = new List<int>();

    [SerializeField]
    private float speed;
    [SerializeField]
    private int distance;
    [SerializeField]
    private int maxBeats;
    [SerializeField]
    private int offset;
    [SerializeField]
    private int offsetY;

    private void Start()
    {
        end_r.transform.position = new Vector3(offset, offsetY, end_r.transform.position.z);
        end_w.transform.position = new Vector3(offset, offsetY, end_r.transform.position.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            UpdateBeat();
            actualSentence.Remove(0);
            Destroy(beats[0]);
            beats.RemoveAt(0);
            Debug.Log(beats.Count);
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
        for(int i = 0; i < beats.Count; i++)
        {
            Destroy(beats[i]);
        }
        beats.Clear();
        for(int i = 0; i < sentence.Length; i++)
        {
            actualSentence.Add(sentence[i]);
            if (sentence[i] == 1) beats.Add(Instantiate(beat));
            else beats.Add(Instantiate(blank));
            beats[i].transform.SetParent(GameObject.FindGameObjectWithTag("CanvasBeat").transform, false);
            beats[i].transform.position = new Vector3(offset - i * distance, offsetY, 10);
            beats[i].transform.localScale += new Vector3(29, 29, 1);
            if (i > maxBeats) beats[i].SetActive(false);
        }
    }

    public void UpdateBeat()
    {
        if (actualSentence.Count > 0)
        {
            if (actualSentence[0] == 0)
            {
                end_r.SetActive(false);
                end_w.SetActive(true);
            }
            else if (actualSentence[0] == 1)
            {
                end_r.SetActive(true);
                end_w.SetActive(false);
            }
            for (int i = 0; i < beats.Count; i++)
            {
                beats[i].transform.position = Vector3.MoveTowards(beats[i].transform.position, new Vector3(beats[i].transform.position.x + distance, beats[i].transform.position.y, beats[i].transform.position.z), speed * distance);
                if (i > maxBeats)
                {
                    beats[i].SetActive(false);
                }
                else
                {
                    beats[i].SetActive(true);
                }
            }
            actualSentence.RemoveAt(0);
            Destroy(beats[0]);
            beats.RemoveAt(0);
        }
    }
}
