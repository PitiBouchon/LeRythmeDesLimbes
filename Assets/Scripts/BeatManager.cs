using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{

    List<GameObject> beats = new List<GameObject>();
    public GameObject end;
    public GameObject beat;
    public GameObject pulse;

    private int pulseCount = 0;

    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private int distance = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            UpdateBeat();
            end.GetComponent<Renderer>().material.color = Color.white;
        }
        else
        {
            end.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public void UpdateBeat()
    {
        if (pulseCount == 0)
        {
            beats.Add(Instantiate(pulse));
            pulseCount++;
        }
        else
        {
            beats.Add(Instantiate(beat));
            pulseCount++;
            if (pulseCount == 4) pulseCount = 0;
        }
        if (beats.Count > 10)
        {
            Destroy(beats[0]);
            beats.RemoveAt(0);
        }
        for (int i = 0; i < beats.Count; i++)
        {
            beats[i].transform.position = Vector3.MoveTowards(beats[i].transform.position, new Vector3(beats[i].transform.position.x+distance, beats[i].transform.position.y, beats[i].transform.position.z), speed);
        }
    }
}
