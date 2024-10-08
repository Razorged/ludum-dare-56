using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public string nextSceneName;
    public MainMenuButtonScript script;
    public GameObject menu;
    public GameObject gameIcons;
    private int score = 0;
    public int maxScore;
    public int critterCount;
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI critterCountText;
    private bool isPaused = false;

    private void Start()
    {
        Time.timeScale = 1;
        critterCount = CountCritters();
        UpdateScoreText();
    }

    private void Update()
    {
        if(score >= maxScore)
        {
            Win();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchMenu();
        }
    }
    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }
    public void SubtractScore()
    {
        score--;
        if (score < 0)
        {
            score = 0;
        }
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
        if (score < 0)
        {
            score = 0;
        }
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        textMeshPro.text = "Cats herded " + score.ToString() + "/" + maxScore.ToString();
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

    private void Win()
    {
        script.GoToScene(nextSceneName);
    }

    private void SwitchMenu()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1;
            gameIcons.SetActive(true);
            menu.SetActive(false);
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0;
            gameIcons.SetActive(false);
            menu.SetActive(true);
        }
    }

}
