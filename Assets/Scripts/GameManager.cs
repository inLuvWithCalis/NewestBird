using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int _playerScore;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Button restartGameBtn;
    [SerializeField] private GameObject gameOverScreen;

    [ContextMenu("Increase Score")]
    private void Awake()
    {
        restartGameBtn.onClick.AddListener(RestartGame);
    }

    public void AddScore(int score)
    {
        _playerScore += score;
        scoreText.text = _playerScore.ToString();
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
