using System.Collections;
using System.Collections.Generic;

public class PlayerData
{
    int score = 0;
    int bestScore = 0;

    public PlayerData(int score, int bestScore)
    {
        this.score = score;
        this.bestScore = bestScore;
    }

    public void AddScore(int scoreValue)
    {
        score += scoreValue;
        if (score > bestScore) bestScore = score;
    }

    public int Score { get => score; set => score = value; }
}
