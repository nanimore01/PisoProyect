using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Advertisements;
public class RewardedAds : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public string gameID = "5788114";
    public string rewardedID = "Rewarded_Android";
    public UnityEvent Reward;
    [SerializeField] bool _testMode = true;
    // Start is called before the first frame update
    void Start()
    {

        InitializeAds();

        LoadAd();

    }



    public void InitializeAds()
    {

        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {

            Advertisement.Initialize(gameID, _testMode, this);

        }

    }



    public void OnInitializationComplete()
    {

        Debug.Log("Unity Ads initialization complete.");

    }



    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {

        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");

    }



    public void LoadAd()
    {

        Advertisement.Load(rewardedID, this);

    }



    public void OnUnityAdsAdLoaded(string adUnitId)
    {

        //

    }



    public void ShowAd()
    {

        Advertisement.Show(rewardedID, this);

    }



    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {

        if (adUnitId.Equals(rewardedID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {

            Debug.Log("Unity Ads Rewarded Ad Completed");

            Reward.Invoke();

        }

    }



    // Implement Load and Show Listener error callbacks:

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {

        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");

        // Use the error details to determine whether to try to load another ad.

        LoadAd();

    }



    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {

        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");

        // Use the error details to determine whether to try to load another ad.

        LoadAd();

    }



    public void OnUnityAdsShowStart(string adUnitId) { }

    public void OnUnityAdsShowClick(string adUnitId) { }
}
