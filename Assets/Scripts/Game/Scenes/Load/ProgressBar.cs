using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : BaseLogic
{
    private RectTransform mRectTransform;
    private float mFillingSpeed;
    
    private float mWidthMin;
    private float mWidthMax;
    private float mWidth;
    
    void Start()
    {
        mRectTransform = GetComponent<RectTransform>();
        mFillingSpeed = 1f;
        
        mWidthMin = 0f;
        mWidthMax = 4.55f;
        mWidth = mWidthMin;
        
        mRectTransform.localScale = new Vector2(mWidthMin, mRectTransform.localScale.y);
    }

    void Update()
    {
        mWidth = mRectTransform.localScale.x;

        if (mWidth < mWidthMax)
        {
            mWidth += mFillingSpeed * Time.deltaTime;
            
            mRectTransform.localScale = new Vector2(mWidth, mRectTransform.localScale.y);
        }
    }
}
