using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveCamera : MonoBehaviour
{
    private float mInitialSize;
    private float mFinalSize;
    private int   mZoomigStep;
    
    private float mInitialX;
    private float mInitialY;
    
    private float mDelta;
    private float mDistance;
    private float mMovingStep;
    
    enum eState
    {
        ZOOMING,
        MOVING,
        COMPLETE,
        INACTION
    }

    private eState mCameraState;
    
    void Start()
    {
        mInitialSize = 850;
        mFinalSize   = 400;
        mZoomigStep  = 300;
        
        Camera.main.orthographicSize = mInitialSize;

        mInitialX = 407;
        mInitialY = 854;

        mDelta      = 0;
        mDistance   = 200;
        mMovingStep = 5;

        transform.position = new Vector3(mInitialX, mInitialY, -10);
        
        mCameraState = eState.ZOOMING;
    }

    void Update()
    {
        if (mCameraState == eState.ZOOMING)
        {
            Zoom();
        }
        else if (mCameraState == eState.MOVING)
        {
            Move();
        }
        else if (mCameraState == eState.COMPLETE)
        {
            OnComplete();
        }
    }

    void Zoom()
    {
        if (Camera.main.orthographicSize > mFinalSize)
        {
            Camera.main.orthographicSize -= mZoomigStep * Time.deltaTime;
        }
        else
        {
            mCameraState = eState.MOVING;
        }
    }
    
    void Move()
    {
        if (mDelta < mDistance)
        {
            mDelta += mMovingStep;

            float diff = mDelta;
            transform.position = new Vector3(mInitialX + diff, mInitialY + diff, -10);
        }
        else
        {
            mCameraState = eState.COMPLETE;
        }
    }

    void OnComplete()
    {
        mCameraState = eState.INACTION;
        SceneManager.LoadScene("Grind", LoadSceneMode.Single);
    }
}
