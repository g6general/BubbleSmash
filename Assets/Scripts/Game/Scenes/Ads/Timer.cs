using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : BaseLogic
{
    private float mTargetTime;
    private Text  mTimer;
    
    void Start()
    {
        mTimer = GameObject.Find("Timer").GetComponent<Text>();
        
        mTargetTime = 10;
        mTimer.text = mTargetTime.ToString();
    }
    void Update()
    {
        mTargetTime -= Time.deltaTime;
        mTimer.text = ((int)mTargetTime).ToString();

        if (mTargetTime <= 0)
        {
            OnComplete();
            mTimer.text = "0";
        }
    }

    private void OnComplete()
    {
        SceneManager.LoadScene("Grind", LoadSceneMode.Single);
    }
}
