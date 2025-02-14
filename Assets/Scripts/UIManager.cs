using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI restartText;

    void Start()
    {
        if(restartText == null)
        {
            Debug.Log("restartText NotFound");
        }
        if (scoreText == null)
        {
            Debug.Log("restartText NotFound");
        }

        restartText.gameObject.SetActive(false);
    }

    public void SetGameOverUI()
    {
        restartText.gameObject.SetActive(true);
    }

    public void Restart()
    {
        restartText.gameObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
