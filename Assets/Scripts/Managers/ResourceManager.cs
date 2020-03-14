using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ResourceManager : Manager 
{
    private ResourceManager()
    {
        Debug.Log("ResourceManager Constructor");
    }

    public static ResourceManager GetManager()
    {
        if (mInstance == null)
            mInstance = new ResourceManager();

        return mInstance as ResourceManager;
    }
}
