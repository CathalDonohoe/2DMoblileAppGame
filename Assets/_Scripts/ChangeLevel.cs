using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    private void Update()    
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "Level 1")
        {
            if (Score.scoreValue > 1000)
            {
                Health.healthValue = 100;
                Score.scoreValue = 0;
                SceneManager.LoadScene("Level 2");    
            }
        }
        
        else if (sceneName == "Level 2")
        {
            if (Score.scoreValue > 2000)
            {
                Health.healthValue = 100;
                Score.scoreValue = 0;
                SceneManager.LoadScene("Level 3");    
            }
        }

        else if (sceneName == "Level 3")
        {
            if (Score.scoreValue > 4000)
            {
                Health.healthValue = 100;
                Score.scoreValue = 0;
                SceneManager.LoadScene("EndGame");    
            }
        }
    }
   
    
}
