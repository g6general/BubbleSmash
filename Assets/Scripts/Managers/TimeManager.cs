using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TimeManager : Manager 
{
    private TimeManager()
    {
        Debug.Log("TimeManager Constructor");
    }

    public static TimeManager GetManager()
    {
        if (mInstance == null)
            mInstance = new TimeManager();

        return mInstance as TimeManager;
    }
}
