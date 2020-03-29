using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading : BaseLogic
{
    private enum eLoadingStatus
    {
        INITIAL_STATE,
        IN_PROGRESS,
        TASK_FAILED,
        INACTIVE_STATE,
        VERSION_CHECKED,
        MANAGERS_LOADED,
        GENERAL_LOADED,
        CONFIGS_LOADED,
        PROFILE_LOADED
    }

    private eLoadingStatus mStatus;

    private Dictionary<eLoadingStatus, bool> mLoadingProgress;

    private ProgressBar mProgressBar;

    private void OnLoadingTerminated()
    {
        string failedTask = "*";

        foreach (var taskStatus in mLoadingProgress)
        {
            if (!taskStatus.Value)
            {
                switch (taskStatus.Key)
                {
                    case eLoadingStatus.VERSION_CHECKED:
                        failedTask = "CheckGameVersion";
                        break;

                    case eLoadingStatus.MANAGERS_LOADED:
                        failedTask = "CheckGameVersion";
                        break;

                    case eLoadingStatus.GENERAL_LOADED:
                        failedTask = "CheckGameVersion";
                        break;

                    case eLoadingStatus.CONFIGS_LOADED:
                        failedTask = "CheckGameVersion";
                        break;

                    case eLoadingStatus.PROFILE_LOADED:
                        failedTask = "CheckGameVersion";
                        break;
                }
            }
        }
        
        Debug.Log(failedTask + " : failed");

        mStatus = eLoadingStatus.INACTIVE_STATE;
    }
    
    private void OnLoadingCompleted()
    { 
        mProgressBar.Fill();
        
        Debug.Log("Loading is completed");
        
        mStatus = eLoadingStatus.INACTIVE_STATE;

        SceneManager.LoadScene("Meta", LoadSceneMode.Single);
    }

    void Start()
    {
        // включить заставку
        
        mStatus = eLoadingStatus.INITIAL_STATE;

        mLoadingProgress = new Dictionary<eLoadingStatus, bool>();
        mLoadingProgress.Add(eLoadingStatus.VERSION_CHECKED, false);
        mLoadingProgress.Add(eLoadingStatus.MANAGERS_LOADED, false);
        mLoadingProgress.Add(eLoadingStatus.GENERAL_LOADED, false);
        mLoadingProgress.Add(eLoadingStatus.CONFIGS_LOADED, false);
        mLoadingProgress.Add(eLoadingStatus.PROFILE_LOADED, false);
        
        mProgressBar = GameObject.Find("ProgressBar").GetComponent<ProgressBar>();
        mProgressBar.Launch(mLoadingProgress.Count, IsTaskCompleted);
    }
    
    void Update()
    {
        switch (mStatus)
        {
            case eLoadingStatus.INITIAL_STATE:
                StartCoroutine("CheckGameVersion");
                break;

            case eLoadingStatus.VERSION_CHECKED:
                mLoadingProgress[eLoadingStatus.VERSION_CHECKED] = true;
                StartCoroutine("LoadManagers");
                break;

            case eLoadingStatus.MANAGERS_LOADED:
                mLoadingProgress[eLoadingStatus.MANAGERS_LOADED] = true;
                StartCoroutine("LoadGeneralObjects");
                break;

            case eLoadingStatus.GENERAL_LOADED:
                mLoadingProgress[eLoadingStatus.GENERAL_LOADED] = true;
                StartCoroutine("LoadConfigs");
                break;

            case eLoadingStatus.CONFIGS_LOADED:
                mLoadingProgress[eLoadingStatus.CONFIGS_LOADED] = true;
                StartCoroutine("LoadProfile");
                break;

            case eLoadingStatus.PROFILE_LOADED:
                mLoadingProgress[eLoadingStatus.PROFILE_LOADED] = true;
                Invoke("OnLoadingCompleted", 2f);
                break;

            case eLoadingStatus.TASK_FAILED:
                OnLoadingTerminated();
                break;
        }
    }

    private bool IsTaskCompleted(int taskIndex)
    {
        var result = false;

        switch (taskIndex)
        {
            case 0:
                result = mLoadingProgress[eLoadingStatus.VERSION_CHECKED];
                break;
            case 1:
                result = mLoadingProgress[eLoadingStatus.MANAGERS_LOADED];
                break;
            case 2:
                result = mLoadingProgress[eLoadingStatus.GENERAL_LOADED];
                break;
            case 3:
                result = mLoadingProgress[eLoadingStatus.CONFIGS_LOADED];
                break;
            case 4:
                result = mLoadingProgress[eLoadingStatus.PROFILE_LOADED];
                break;
        }

        return result;
    }

    IEnumerator CheckGameVersion()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Check game version");
        mStatus = eLoadingStatus.VERSION_CHECKED;
        yield return null;
    }
    
    IEnumerator LoadManagers()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Load managers");
        mStatus = eLoadingStatus.MANAGERS_LOADED;
        yield return null;
    }
    
    IEnumerator LoadGeneralObjects()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Load general objects");
        mStatus = eLoadingStatus.GENERAL_LOADED;
        yield return null;
    }
    
    IEnumerator LoadConfigs()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Load configs");
        mStatus = eLoadingStatus.CONFIGS_LOADED;
        yield return null;
    }
    
    IEnumerator LoadProfile()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Load profile (save + settings)");
        mStatus = eLoadingStatus.PROFILE_LOADED;
        yield return null;
    }
}
