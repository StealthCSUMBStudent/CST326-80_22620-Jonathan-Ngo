using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public float scoreOverall = 0;
    public float highScore = 0;
    void Start()
    {
        // todo - sign up for notification about enemy death 
        Enemy.OnEnemyDied += OnEnemyDied;
        Barrier.OnBarrierGone += OnBarrierGone;
        Player.OnPlayerDied += OnPlayerDied;
    }
    private void OnDestroy()
    {
        Enemy.OnEnemyDied -= OnEnemyDied;
        Barrier.OnBarrierGone -= OnBarrierGone;
        Player.OnPlayerDied -= OnPlayerDied;
    }
    void OnEnemyDied(float score)
    {
        Debug.Log($"Killed enemy worth " + score);
        scoreOverall += score;
        if (scoreOverall > highScore)
        {
            highScore = scoreOverall;
            if (highScore < 100)
            {
                highScoreText.text = $"HIGH SCORE\n00" + ((int)highScore).ToString();
            }
            else if (highScore < 1000 && highScore >= 100)
            {
                highScoreText.text = $"HIGH SCORE\n0" + ((int)highScore).ToString();
            }
            else if (highScore < 10000 && highScore >= 1000)
            {
                highScoreText.text = $"HIGH SCORE\n" + ((int)highScore).ToString();
            }
        }
        if (scoreOverall < 100)
        {
            scoreText.text = $"SCORE\n00" + ((int)scoreOverall).ToString();
        }
        else if (scoreOverall < 1000 && scoreOverall >= 100)
        {
            scoreText.text = $"SCORE\n0" + ((int)scoreOverall).ToString();
        }
        else if (scoreOverall < 10000 && scoreOverall >= 1000)
        {
            scoreText.text = $"SCORE\n" + ((int)scoreOverall).ToString();
        }
    }

    void OnBarrierGone()
    {
        Debug.Log($"The barrier has been destroyed");
    }
    void Update()
    {
        if (Keyboard.current.rKey.isPressed)
        {
            scoreOverall = 0;
            scoreText.text = $"SCORE\n000" + ((int)scoreOverall).ToString();
        }
    }
    void OnPlayerDied()
    {
        Debug.Log($"The Player has died.");
    }
}
