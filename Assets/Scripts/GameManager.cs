using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("HUD")]
    [SerializeField] private TextMeshProUGUI ScoreTextUI;
    [SerializeField] private TextMeshProUGUI TotalBallsUI;

    [Header("GAME OVER UI")]
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private Button RestartButton;


    private int _totalScore;

    public static GameManager Instance;

    void Start()
    {
        Instance = this;
        Time.timeScale = 1;

        RestartButton.onClick.AddListener(Restart);
    }

    private void LateUpdate()
    {
        int totalBalls = GameObject.FindGameObjectsWithTag("Ball").Length;

        if (totalBalls == 0)
        {
            ShowGameOver();
        } else
        {
            TotalBallsUI.text = totalBalls.ToString("00");
        }
    }

    private void ShowGameOver()
    {
        Time.timeScale = 0;
        GameOverUI.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void UpdateScore(int score)
    {
        _totalScore += score;
        ScoreTextUI.text = _totalScore.ToString("000");
    }
}
