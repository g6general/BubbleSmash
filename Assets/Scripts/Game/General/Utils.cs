using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskQueue
{
    public delegate void CallbackOnTerminated(string taskName);
    public delegate void CallbackOnCompleted();
    public delegate bool Task();

    private List<Tuple<string, bool, Task>> mTaskQueue;
    private CallbackOnTerminated mOnTerminated;
    private CallbackOnCompleted mOnCompleted;

    public TaskQueue(CallbackOnTerminated func1 = null, CallbackOnCompleted func2 = null)
    {
        mTaskQueue = new List<Tuple<string, bool, Task>>();
        
        mOnTerminated = func1 ?? OnTerminated;
        mOnCompleted = func2 ?? OnCompleted;
    }

    public void AddTask(string taskName, Task func)
    {
        mTaskQueue.Add(new Tuple<string, bool, Task>(taskName, false, func));
    }
    
    public void Launch()
    {
        for (var i = 0; i < mTaskQueue.Count; ++i)
        {
            if (!mTaskQueue[i].Item3())
            {
                mOnTerminated(mTaskQueue[i].Item1);
                return;
            }

            mTaskQueue[i] = new Tuple<string, bool, Task>(mTaskQueue[i].Item1, true, mTaskQueue[i].Item3);
        }

        mOnCompleted();
    }

    public bool IsTaskCompleted(string taskName)
    {
        var result = mTaskQueue.Find(task => task.Item1 == taskName);
        return (result == null) ? false : result.Item2;
    }

    public bool IsTaskCompleted(int taskIndex)
    {
        if (taskIndex >= mTaskQueue.Count)
            return false;
        
        return IsTaskCompleted(mTaskQueue[taskIndex].Item1);
    }

    public int NumberOfTasks()
    {
        return mTaskQueue.Count;
    }

    private void OnTerminated(string taskName)
    {
        // Do nothing
    }
    
    private void OnCompleted()
    {
        // Do nothing
    }
}
