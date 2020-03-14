using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LogManager : Manager 
{
    private LogManager()
    {
        Debug.Log("LogManager Constructor");
    }

    public static LogManager GetManager()
    {
        if (mInstance == null)
            mInstance = new LogManager();

        return mInstance as LogManager;
    }
}
