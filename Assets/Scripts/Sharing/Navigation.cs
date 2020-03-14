using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Navigation
{
    protected static Navigation mInstance;
    
    private Navigation()
    {
        Debug.Log("Navigation Constructor");
    }

    public static Navigation GetNavigation()
    {
        if (mInstance == null)
            mInstance = new Navigation();

        return mInstance;
    }
}
