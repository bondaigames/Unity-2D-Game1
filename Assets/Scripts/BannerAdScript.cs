using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAdScript : MonoBehaviour
{
#if UNITY_IOS
    private string gameId = "3562508";
#elif UNITY_ANDROID
    private string gameId = "3562509";
#else
    private string gameId = "1234567";
#endif

    public string placementId = "banner";
    public bool testMode = false;

    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize (gameId, testMode);
        StartCoroutine (ShowBannerWhenReady ());
    }

    IEnumerator ShowBannerWhenReady () {
        while (!Advertisement.IsReady (placementId)) {
            yield return new WaitForSeconds (0.5f);
        }
        Advertisement.Banner.SetPosition (BannerPosition.BOTTOM_CENTER);
        Advertisement.Banner.Show (placementId);
    }

    
}
