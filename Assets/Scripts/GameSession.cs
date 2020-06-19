using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;

public class GameSession : MonoBehaviour
{
    //public static GameSession Instance { get; private set; }

    int score = 0;

    string HIGH_SCORE = "HighScore";
    string COIN = "Coin";
    int showAdsCount = 0;
    int randomNumberShowAds = 0;

    //private void Awake()
    //{
    //    SetupSingleton();
    //}
    //PlayerData data;
    // Start is called before the first frame update
    void Start()
    {
        SetupSingleton();

        //AddMoreCoin(254000);
        //SubtractCoin(254000);
        //Debug.Log(Application.persistentDataPath);
        //data = SaveSystem.LoadPlayer();
        //if (data == null)
        //    data = new PlayerData(0, 0);
    }

    private void SetupSingleton()
    {
        //if (Instance != null)
        //{
        //    Destroy(gameObject);
        //}
        //else
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(gameObject);
        //}

        int numberOfGameSession = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSession > 1)
        {
            //RandomShowAdsCount();
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    internal void ResetGame()
    {
        score = 0;
        //Destroy(gameObject);
    }

    public void AddScore()
    {
        int scoreValue = 1;

        //List<ShopItem> items = SaveSystem.LoadShopItems();
        ShopItem item = SaveSystem.LoadShopItems()?.SingleOrDefault(o => o.selected == true);

        if (item != null)
        {
            scoreValue = item.star;
        }
        score += scoreValue;
        AddMoreCoin(scoreValue);

        //GET AND SET High score
        int highScore = PlayerPrefs.GetInt(HIGH_SCORE);
        Debug.Log("score: " + score);
        Debug.Log("high score: " + highScore);

        if (score > highScore)
        {
            Debug.Log("saving high score: " + score);
            PlayerPrefs.SetInt(HIGH_SCORE, score);
            FindObjectOfType<LeaderboardManager>().AddScoreToLeaderboard(GPGSIds.leaderboard_high_score, score);

            AnalyticsEvent.Custom("highest_score", new Dictionary<string, object>
            {
                { "score", score },
                { "time_elapsed", Time.timeSinceLevelLoad }
            });
        }
    }

    public int GetCoin()
    {
        return PlayerPrefs.GetInt(COIN, 0);
    }

    public int GetScore()
    {
        return this.score;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE, 0);
    }

    public void AddMoreCoin(int coin)
    {
        //Get and Set Coin
        int currentCoin = PlayerPrefs.GetInt(COIN);
        currentCoin += coin;
        AnalyticsEvent.Custom("Coin", new Dictionary<string, object>
        {
            { "total_coin", currentCoin },
            { "time_elapsed", Time.timeSinceLevelLoad }
        });
        PlayerPrefs.SetInt(COIN, currentCoin);
    }

    public void SubtractCoin(int coin)
    {
        //Get and Set Coin
        int currentCoin = PlayerPrefs.GetInt(COIN);
        currentCoin -= coin;
        PlayerPrefs.SetInt(COIN, currentCoin);
    }

    public void ShowLeaderboards()
    {
        FindObjectOfType<LeaderboardManager>().ShowLeaderboards();
    }

    public void RandomShowAdsCount()
    {
        Debug.Log("Random number show ads before: " + randomNumberShowAds);
        randomNumberShowAds = Random.Range(3, 7);
        Debug.Log("Random number show ads: " + randomNumberShowAds);
    }

    public void IncreaseShowAdsCount()
    {
        if (randomNumberShowAds == 0)
            RandomShowAdsCount();
        showAdsCount++;
        Debug.Log("Show ads count: " + showAdsCount);
    }

    public void ShowAds()
    {
        Debug.Log("show count: " + showAdsCount + " random: " + randomNumberShowAds);
        if (showAdsCount == randomNumberShowAds)
        {
            AnalyticsEvent.Custom("show_ads", new Dictionary<string, object>
            {
                { "time_elapsed", Time.timeSinceLevelLoad }
            });

            showAdsCount = 0;
            RandomShowAdsCount();
            InterstitialAdsScript ads = new InterstitialAdsScript();
            ads.ShowAds();
        }
    }

}
