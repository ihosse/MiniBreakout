using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreTxt;
    [SerializeField] private TextMeshProUGUI livesTxt;
    [SerializeField] private Rigidbody2D ball;
    [SerializeField] private Transform player;
    [SerializeField] private int totalNumberOfBlocks;
    [SerializeField] private int killBlockScore;
    [SerializeField] private int initLives;

    private Vector2 iniBallPosition;
    private int score;
    private int lives;

    void Start()
    {
        iniBallPosition = ball.transform.position;
        ball.gameObject.SetActive(false);

        lives = initLives;

        Invoke("StartRound", 3);
    }

    private void StartRound()
    {
        ball.gameObject.SetActive(true);
        ball.transform.position = iniBallPosition;
        UpdateScoreAndLives();
    }

    private void ReloadScene() 
    {
        SceneManager.LoadScene(0);
    }

    public void ResetBall()
    {
        ball.transform.position = Vector2.zero;
    }

    private void UpdateScoreAndLives()
    {
        scoreTxt.text = score.ToString();
        livesTxt.text = lives.ToString();
    }

    public void AddPoint()
    {
        score += killBlockScore;

        UpdateScoreAndLives();

        if (score >= totalNumberOfBlocks * killBlockScore)
        {
            ball.gameObject.SetActive(false);
            Invoke("ReloadScene", 1);
        }
    }

    public void RemoveLife()
    {
        lives--;
        UpdateScoreAndLives();
        ball.gameObject.SetActive(false);

        if (lives <= 0)
        {
            Invoke("ReloadScene", 1);
        }
        else 
        {
            Invoke("StartRound", 1);
        }
    }
}