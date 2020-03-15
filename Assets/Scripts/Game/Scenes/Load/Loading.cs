using System.Collections;
using System.Collections.Generic;
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
    
    void Start()
    {
        mStatus = eLoadingStatus.INITIAL_STATE;
        
        // включить заставку
    }
    
    void Update()
    {
        switch (mStatus)
        {
            case eLoadingStatus.INITIAL_STATE:
                StartCoroutine("CheckGameVersion");
                break;
            case eLoadingStatus.VERSION_CHECKED:
                StartCoroutine("LoadManagers");
                break;
            case eLoadingStatus.MANAGERS_LOADED:
                StartCoroutine("LoadGeneralObjects");
                break;
            case eLoadingStatus.GENERAL_LOADED:
                StartCoroutine("LoadConfigs");
                break;
            case eLoadingStatus.CONFIGS_LOADED:
                StartCoroutine("LoadProfile");
                break;
            case eLoadingStatus.PROFILE_LOADED:
                // запуск мета гейма
                break;
        }
    }

    IEnumerator CheckGameVersion()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Check game version");
        yield return new WaitForSeconds(1f);    // temp
        mStatus = eLoadingStatus.VERSION_CHECKED;
        yield return null;
    }
    
    IEnumerator LoadManagers()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Load managers");
        yield return new WaitForSeconds(1f);    // temp
        mStatus = eLoadingStatus.MANAGERS_LOADED;
        yield return null;
    }
    
    IEnumerator LoadGeneralObjects()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Load general objects");
        yield return new WaitForSeconds(1f);    // temp
        mStatus = eLoadingStatus.GENERAL_LOADED;
        yield return null;
    }
    
    IEnumerator LoadConfigs()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Load configs");
        yield return new WaitForSeconds(1f);    // temp
        mStatus = eLoadingStatus.CONFIGS_LOADED;
        yield return null;
    }
    
    IEnumerator LoadProfile()
    {
        mStatus = eLoadingStatus.IN_PROGRESS;
        Debug.Log("Load profile (save + settings)");
        yield return new WaitForSeconds(1f);    // temp
        mStatus = eLoadingStatus.PROFILE_LOADED;
        yield return null;
    }
}
