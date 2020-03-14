using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Game
{
    private static Game mInstance;
    
    private Game()
    {
        Debug.Log("Game Constructor");
    }

    public static Game GetGame()
    {
        if (mInstance == null)
            mInstance = new Game();

        return mInstance;
    }
}
