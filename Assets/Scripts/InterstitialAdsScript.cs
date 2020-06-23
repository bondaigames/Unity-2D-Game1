using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAdsScript : MonoBehaviour
{
#if UNITY_IOS
    private string gameId = "3562508";
#elif UNITY_ANDROID
    private string gameId = "3562509";
#else
    private string gameId = "1234567";
#endif

    private string myPlacementId = "Interstitial";
    //bool testMode = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("testing show ads");
        // Initialize the Ads service:
        Advertisement.Initialize(gameId, false);
        // Show an ad:
        
    }

    public void ShowAds()
    {
        Advertisement.Show(myPlacementId);
    }
}
