using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Parameters
{
    protected static Parameters mInstance;
    
    private Parameters()
    {
        Debug.Log("Parameters Constructor");
    }

    public static Parameters GetParameters()
    {
        if (mInstance == null)
            mInstance = new Parameters();

        return mInstance;
    }
}
