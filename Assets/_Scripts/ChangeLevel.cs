using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    private void Update() {
        if (Score.scoreValue > 2000)
        {
            Health.healthValue = 100;
            Score.scoreValue = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);    
        }
    }
   
}
