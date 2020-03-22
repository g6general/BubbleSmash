using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : BaseLogic
{
    private RectTransform mRectTransform;
    
    private float mFillingSpeedSlow;
    private float mFillingSpeedFast;
    private float mCurrentSpeed;
    
    private float mMaxWidth;
    
    enum eProgressStatus
    {
        INACTION,
        WAITING,
        INPROGRESS,
        COMPLETED
    }

    private eProgressStatus mStatus;
    
    public delegate bool CallBack(int taskNumber);

    private CallBack mIsLoadingCompleted;
    private int mNumberOfTasks;
    private int mCurrentTaskIndex;

    void Start()
    {
        mRectTransform = GetComponent<RectTransform>();
        mRectTransform.sizeDelta = new Vector2(0, mRectTransform.sizeDelta.y);
        
        mFillingSpeedSlow = 120f;    // TEMP
        mFillingSpeedFast = 240f;    // TEMP
        mCurrentSpeed = mFillingSpeedSlow;

        mMaxWidth = 452f;    // TEMP
        
        mStatus = eProgressStatus.INACTION;
        mNumberOfTasks = 1;
        mCurrentTaskIndex = 0;
        
        // TEMP
        Launch(4, function);
        // TEMP
    }

    void Update()
    {
        if (mStatus == eProgressStatus.WAITING)
        {
            if (mIsLoadingCompleted(mCurrentTaskIndex))
            {
                ++mCurrentTaskIndex;

                if (mCurrentTaskIndex == mNumberOfTasks)
                {
                    mStatus = eProgressStatus.COMPLETED;
                }
                else
                {
                    mStatus = eProgressStatus.INPROGRESS;
                    mCurrentSpeed = mFillingSpeedSlow;
                }
            }
        }
        else if (mStatus == eProgressStatus.INPROGRESS)
        {
            if (mIsLoadingCompleted(mCurrentTaskIndex))
            {
                mCurrentSpeed = mFillingSpeedFast;
            }
            
            int currentWidth = (int)((mMaxWidth / mNumberOfTasks) * (mCurrentTaskIndex + 1));
            
            if (mRectTransform.sizeDelta.x < currentWidth)
            {
                float newWidth = mRectTransform.sizeDelta.x + mCurrentSpeed * Time.deltaTime;
                mRectTransform.sizeDelta = new Vector2(newWidth, mRectTransform.sizeDelta.y);
            }
            else
            {
                mStatus = eProgressStatus.WAITING;
            }
            
        }
        else if (mStatus == eProgressStatus.COMPLETED)
        {
            Debug.Log("LOAD META GAME");
            mStatus = eProgressStatus.INACTION;
        }
    }

    public void Launch(int numberOfTasks, CallBack IsLoadingCompleted)
    {
        mNumberOfTasks = numberOfTasks;
        mIsLoadingCompleted = IsLoadingCompleted;
        mStatus = eProgressStatus.INPROGRESS;
    }
    
    // TEMP
    public bool function(int test)
    {
        return true;
    }
    // TEMP
}
