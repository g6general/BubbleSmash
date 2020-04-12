using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temp : BaseLogic
{
    private Text  mTimerString;
    private float mTimer;
    private float mLimit;
    
    private static Color mYellowColor = new Color(0.78f, 0.73f, 0.06f, 1f);
    private static Color mRedColor    = new Color(0.8f, 0f, 0.1f, 0.7f);

    void Start()
    {
        mTimer = 0;
        mLimit = 16;
        
        mTimerString = GameObject.Find("Timer").GetComponent<Text>();
        mTimerString.color = mYellowColor;
    }
    
    void Update()
    {
        mTimer += Time.deltaTime;
        
        mTimerString.text = ((int)mTimer).ToString();

        if (mTimer >= mLimit && mTimerString.color != mRedColor)
        {
            mTimerString.color = mRedColor;
        }
            
    }

    public void onButtonWinClick()
    {
        Debug.Log("onButtonWinClick()");
    }

    public void onButtonLoseClick()
    {
        Debug.Log("onButtonLoseClick()");
    }
}
