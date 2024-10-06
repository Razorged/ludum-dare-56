using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicScript : MonoBehaviour
{
    private int score = 0;
    public int maxScore = 4;
    public int critterCount;
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI critterCountText;

    private void Start()
    {
        critterCount = CountCritters();
        maxScore = CountCritters();
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

    public void AddScore(int count)
    {
        score += count;
        UpdateScoreText();
    }
    public void SubtractScore(int count)
    {
        score -= count;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        textMeshPro.text = score.ToString() + "/" + maxScore.ToString();
        critterCountText.text = critterCount.ToString();
    }

    private int CountCritters()
    {
        GameObject[] critterObjects = GameObject.FindGameObjectsWithTag("Critter");
        GameObject[] critterBallObjects = GameObject.FindGameObjectsWithTag("CritterBall");
        return critterBallObjects.Length + critterObjects.Length;
    }


    public void SubtractCritter()
    {
        critterCount--;
        UpdateScoreText();
    }
    public void AddCritter()
    {
        critterCount++;
        UpdateScoreText();
    }

}
