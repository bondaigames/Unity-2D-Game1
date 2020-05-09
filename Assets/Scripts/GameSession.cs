using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;

    string HIGH_SCORE   = "HighScore";
    string COIN         = "Coin";

    //PlayerData data;
    // Start is called before the first frame update
    void Start()
    {
        SetupSingleton();
        //data = SaveSystem.LoadPlayer();
        //if (data == null)
        //    data = new PlayerData(0, 0);
    }

    private void SetupSingleton()
    {
        int numberOfGameSession = FindObjectsOfType<GameSession>().Length;
        if (numberOfGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    internal void ResetGame()
    {
        Destroy(gameObject);
    }

    public void AddScore(int scoreValue)
    {
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
            //FindObjectOfType<PlayGameServices>().AddScoreToLeaderboard(GPGSIds.leaderboard_high_score, score);
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
        PlayerPrefs.SetInt(COIN, currentCoin);
    }

    public void ShowLeaderboards()
    {
        Debug.Log("hello world");
        FindObjectOfType<PlayGameServices>().ShowLeaderboards();
    }

}
