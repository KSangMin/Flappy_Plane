using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private int _score = 0;

    public void AddScore(int s)
    {
        _score += s;
        Debug.Log(_score);
        UIManager.Instance.UpdateScore(_score);
    }

    public void GameOver()
    {
        Debug.Log("게임오버");
        UIManager.Instance.SetGameOverUI();
    }

    public void RestartGame()
    {
        UIManager.Instance.Restart();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        _score = 0;
        UIManager.Instance.UpdateScore(_score);
    }
}
