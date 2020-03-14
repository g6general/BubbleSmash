using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SoundManager : Manager 
{
    private SoundManager()
    {
        Debug.Log("SoundManager Constructor");
    }

    public static SoundManager GetManager()
    {
        if (mInstance == null)
            mInstance = new SoundManager();

        return mInstance as SoundManager;
    }
}
