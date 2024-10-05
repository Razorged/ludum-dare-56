using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicScript : MonoBehaviour
{
    private int score = 0;
    public int maxScore = 4;
    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }
    public void SubtractScore()
    {
        score--;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        textMeshPro.text = score.ToString() + "/" + maxScore.ToString();
    }


}
