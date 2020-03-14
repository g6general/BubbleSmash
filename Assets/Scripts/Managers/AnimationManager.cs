using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AnimationManager : Manager 
{
    private AnimationManager()
    {
        Debug.Log("AnimationManager Constructor");
    }

    public static AnimationManager GetManager()
    {
        if (mInstance == null)
            mInstance = new AnimationManager();

        return mInstance as AnimationManager;
    }
}
