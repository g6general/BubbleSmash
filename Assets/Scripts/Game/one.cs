using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class one : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Scene \"one\"");
        
        //var manager = TestManager.GetInctance();
        
        //Debug.Log("X: " + manager.x);
        //Debug.Log("Y: " + manager.y);

        //manager.Increment();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("two", LoadSceneMode.Single);
        }
    }
}
