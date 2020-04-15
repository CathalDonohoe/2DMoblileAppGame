using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //declaration of variables
    public static int healthValue = 100;
    Text health;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {   
        //for health UI
        health.text = "Health: " + healthValue;
    }
}
