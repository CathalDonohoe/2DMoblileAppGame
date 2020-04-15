using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{

    //declaration of variables
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        //if player presses escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if game is paused == true
            if(gameIsPaused)
            {
                Resume();
            } else
            {
                //calls function
            Pause();

            }
        }

        
    }


    public void Resume()
    {
        //sets UI to unactive and time back to 1
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }


    void Pause()
    {
        //sets UI screen to active and time to 0
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }


    //loads menu scene and sets values back to original
    public void LoadMenu()
    {
        Health.healthValue = 100;
        Score.scoreValue = 0;
        SceneManager.LoadScene("MainMenu");

    }

  

    // quits game
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        
    }
}
