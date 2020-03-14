using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GameData
{
    protected static GameData mInstance;
    
    private GameData()
    {
        Debug.Log("GameData Constructor");
    }

    public static GameData GetGameData()
    {
        if (mInstance == null)
            mInstance = new GameData();

        return mInstance;
    }
}
