using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;

    string HIGH_SCORE   = "HighScore";
    string SCORE        = "SCORE"; 
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
        //PlayerPrefs.SetInt(SCORE, score); 

        int highScore = PlayerPrefs.GetInt(HIGH_SCORE);
        Debug.Log("score: " + score);
        Debug.Log("high score: " + highScore);

        if (score > highScore)
        {
            Debug.Log("saving high score: " + score);
            PlayerPrefs.SetInt(HIGH_SCORE, score);
        }
    }

    public int GetScore()
    {
        return this.score;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE, 0);
    }

}
