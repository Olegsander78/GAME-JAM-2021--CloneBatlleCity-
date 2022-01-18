using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public GameObject GameOverMenu;
    public GameObject OptionBtn;
    public GameObject OptionMenuWindow;
    public GameObject VictoryWindow;
    
    public void OpenGameOverWindow()
    {
        GameOverMenu.SetActive(true);
        OptionBtn.SetActive(false);
        Time.timeScale = 0f;
    }

    public void OpenVictoryWindow()
    {
        VictoryWindow.SetActive(true);
        OptionBtn.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MenuStart");
        Time.timeScale = 1f;
    }

    public void ResumeGame()
    {
        OptionMenuWindow.SetActive(false);
        OptionBtn.SetActive(true);
        Time.timeScale = 1f;
    }

    public void ClickOptionButton()
    {
        OptionMenuWindow.SetActive(true);
        OptionBtn.SetActive(false);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
