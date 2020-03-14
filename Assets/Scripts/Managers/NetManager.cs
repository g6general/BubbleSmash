using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class NetManager : Manager 
{
    private NetManager()
    {
        Debug.Log("NetManager Constructor");
    }

    public static NetManager GetManager()
    {
        if (mInstance == null)
            mInstance = new NetManager();

        return mInstance as NetManager;
    }
}
