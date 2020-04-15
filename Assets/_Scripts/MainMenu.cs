using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //to start game on level 1
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    //to quit game
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    //to load tutorial scene
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
