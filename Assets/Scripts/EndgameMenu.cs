using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgameMenu : MonoBehaviour
{
    public void startMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
