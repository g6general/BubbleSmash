using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class two : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Scene \"two\"");
        
        //var manager = TestManager.GetInctance();
        
        //Debug.Log("X: " + manager.x);
        //Debug.Log("Y: " + manager.y);
        
        //manager.Increment();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("one", LoadSceneMode.Single);
        }
    }
}
