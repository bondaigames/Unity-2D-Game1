using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdScript : MonoBehaviour, IUnityAdsListener
{
#if UNITY_IOS
    private string gameId = "3562508";
#elif UNITY_ANDROID
    private string gameId = "3562509";
#endif

    private string placementId = "banner";
    //public bool testMode = false;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize (gameId, false);
        StartCoroutine(ShowBannerWhenReady());
    }

    private void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    IEnumerator ShowBannerWhenReady () {
        while (!Advertisement.IsReady (placementId)) {
            yield return new WaitForSeconds (0.5f);
        }
        Advertisement.Banner.SetPosition (BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show (placementId);
    }

    public void OnUnityAdsReady(string placementId)
    {

    }

    public void OnUnityAdsDidError(string message)
    {
        Advertisement.Initialize(gameId, false);
        StartCoroutine(ShowBannerWhenReady());
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Failed)
        {
            Advertisement.Initialize(gameId, false);
            StartCoroutine(ShowBannerWhenReady());
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }
}
