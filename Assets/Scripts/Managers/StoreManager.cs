using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class StoreManager : Manager 
{
    private StoreManager()
    {
        Debug.Log("StoreManager Constructor");
    }

    public static StoreManager GetManager()
    {
        if (mInstance == null)
            mInstance = new StoreManager();

        return mInstance as StoreManager;
    }
}
