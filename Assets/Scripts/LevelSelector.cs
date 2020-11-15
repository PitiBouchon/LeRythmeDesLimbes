using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void SelectLevel(int level)
    {
        PlayerPrefs.SetInt("levelPlayed", level);
        Destroy(GameObject.Find("MenuMusic"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(levelName);
    }
}
