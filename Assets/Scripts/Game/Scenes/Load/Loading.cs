using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Loading : BaseLogic
{
    private enum eLoadingStatus
    {
        INITIAL_STATE,
        IN_PROGRESS,
        VERSION_CHECKED,
        MANAGERS_LOADED,
        GENERAL_LOADED,
        CONFIGS_LOADED,
        PROFILE_LOADED
    }

    private eLoadingStatus mStatus;

    private TaskQueue mTaskQueue;

    private ProgressBar mProgressBar;
    
    private void OnTerminated(string taskName)
    {
        Debug.Log(taskName + " : failed");
    }
    
    private void OnCompleted()
    { 
        mProgressBar.Fill();
        
        Debug.Log("Loading is completed");
        
        // load meta game
    }

    void Start()
    {
        // включить заставку
        
        mStatus = eLoadingStatus.INITIAL_STATE;
        mProgressBar = GameObject.Find("ProgressBar").GetComponent<ProgressBar>();

        mTaskQueue = new TaskQueue(OnTerminated, OnCompleted);
        mTaskQueue.AddTask("CheckGameVersion", CheckGameVersion);
        mTaskQueue.AddTask("LoadManagers", LoadManagers);
        mTaskQueue.AddTask("LoadGeneralObjects", LoadGeneralObjects);
        mTaskQueue.AddTask("LoadConfigs", LoadConfigs);
        mTaskQueue.AddTask("LoadProfile", LoadProfile);
        
        mProgressBar.Launch(mTaskQueue.NumberOfTasks(), IsTaskCompleted);
        StartCoroutine("LoadingProcess");
    }
    
    IEnumerator LoadingProcess()
    {
        mTaskQueue.Launch();
        yield return null;
    }

    private bool IsTaskCompleted(int taskIndex)
    {
        return mTaskQueue.IsTaskCompleted(taskIndex);
    }

    private bool CheckGameVersion()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Check game version");
        mStatus = eLoadingStatus.VERSION_CHECKED;
        return true;
    }
    
    private bool LoadManagers()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Load managers");
        mStatus = eLoadingStatus.MANAGERS_LOADED;
        return true;
    }
    
    private bool LoadGeneralObjects()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Load general objects");
        mStatus = eLoadingStatus.GENERAL_LOADED;
        return true;
    }
    
    private bool LoadConfigs()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Load configs");
        mStatus = eLoadingStatus.CONFIGS_LOADED;
        return true;
    }
    
    private bool LoadProfile()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Load profile (save + settings)");
        mStatus = eLoadingStatus.PROFILE_LOADED;
        return true;
    }
}
