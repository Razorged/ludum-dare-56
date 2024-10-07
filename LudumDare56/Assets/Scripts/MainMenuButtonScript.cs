using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonScript : MonoBehaviour
{

    public GameObject noneEquippedPanel;
    public GameObject glueGunEquippedPanel;
    public GameObject unglueGunEquippedPanel;

    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void GoToMainMenu()
    {
        Debug.Log("aaa");
        SceneManager.LoadScene("MainMenu");
    }

    public void setGlueGunActive()
    {
        noneEquippedPanel.SetActive(false);
        unglueGunEquippedPanel.SetActive(false);
        glueGunEquippedPanel.SetActive(true);
    }

    public void setUnglueGunActive()
    {
        noneEquippedPanel.SetActive(false);
        unglueGunEquippedPanel.SetActive(true);
        glueGunEquippedPanel.SetActive(false);
    }
}
