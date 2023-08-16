using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGameStates : MonoBehaviour
{
    public GameObject NewGamePanel;
    public GameObject GameOverPanel;
    public GameObject GameOnPanel;

    private void Start()
    {
        NewGamePanel.SetActive(true);
        GameOverPanel.SetActive(false);
        GameOnPanel.SetActive(false);
    }

    public void HandleGameOver()
    {
        Debug.Log("Game Over");
        GameOverPanel.SetActive(true);
        GameOnPanel.SetActive(false);

        ShowScore();
    }

    private void ShowScore()
    {
        // Get the labels in the Game Over panel
        var scoreLabel = GameOverPanel.transform.Find("ScoreLabel").GetComponent<TMPro.TextMeshProUGUI>();
        var accuracyLabel = GameOverPanel.transform.Find("AccuracyLabel").GetComponent<TMPro.TextMeshProUGUI>();

        // Calculate the accuracy
        var accuracy = GameManager.ShotsFired == 0 ? 0 : (float)GameManager.Score / GameManager.ShotsFired;
        accuracy = (float)Math.Round(accuracy * 100, 0);

        // Set the labels
        scoreLabel.text = $"Score: {GameManager.Score}";
        accuracyLabel.text = $"Accuracy: {accuracy}%";
    }

    public void HandleGameStarted()
    {
        Debug.Log("Game Started");
        NewGamePanel.SetActive(false);
        GameOverPanel.SetActive(false);
        GameOnPanel.SetActive(true);
    }
}