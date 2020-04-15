using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    private void Update()    
    {
        //gets current scenes name, and assigns it to a string.
        //then compares that name to atten which scene is current.
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "Level 1")
        {
            //if score reaches 1000 on level 1, it changes to level 2
            if (Score.scoreValue > 1000)
            {
                //resets health and score
                Health.healthValue = 100;
                Score.scoreValue = 0;
                SceneManager.LoadScene("Level 2");    
            }
        }
        
        else if (sceneName == "Level 2")
        {
            //if score reaches 2000 on level 2, it changes to level 3
            if (Score.scoreValue > 2000)
            {
                //resets health and score
                Health.healthValue = 100;
                Score.scoreValue = 0;
                SceneManager.LoadScene("Level 3");    
            }
        }

        else if (sceneName == "Level 3")
        {
            //if score reaches 4000 on level 3, it changes tot eh endgame scene
            if (Score.scoreValue > 4000)
            {
                //resets health and score
                Health.healthValue = 100;
                Score.scoreValue = 0;
                SceneManager.LoadScene("EndGame");    
            }
        }
    }
   
    
}
