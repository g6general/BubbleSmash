using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TextManager : Manager 
{
    private TextManager()
    {
        Debug.Log("TextManager Constructor");
    }

    public static TextManager GetManager()
    {
        if (mInstance == null)
            mInstance = new TextManager();

        return mInstance as TextManager;
    }
}
