using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject MenuStart;
    public NumberOfPlayers NumberOfPlayers;        

    public void StartOnePlayer()
    {
        NumberOfPlayers.NumberPlayers = 1;
        SceneManager.LoadScene("SceneLevel1");        
    }

    public void StartTwoPlayers()
    {
        NumberOfPlayers.NumberPlayers = 2;
        SceneManager.LoadScene("SceneLevel1");        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
