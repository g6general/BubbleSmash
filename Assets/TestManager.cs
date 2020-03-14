using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager
{
    private static TestManager mInstance;

    public int x = 0;
    public int y = 0;

    private TestManager()
    {
        Debug.Log("Constructor");
    }

    public static TestManager GetInctance()
    {
        if (mInstance == null)
            mInstance = new TestManager();

        return mInstance;
    }

    public void Increment()
    {
        ++x;
        ++y;
    }
}
