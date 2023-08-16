using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandleScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public void HandleScoreUpdate(int score)
    {
        Debug.Log($"Score updated to {score}");
        scoreText.text = $"Score: {score}";
    }
}
