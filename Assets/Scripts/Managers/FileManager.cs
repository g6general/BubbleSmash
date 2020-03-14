using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FileManager : Manager 
{
    private FileManager()
    {
        Debug.Log("FileManager Constructor");
    }

    public static FileManager GetManager()
    {
        if (mInstance == null)
            mInstance = new FileManager();

        return mInstance as FileManager;
    }
}
