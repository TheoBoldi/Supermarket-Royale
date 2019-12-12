using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);

        GameManager.player1scoreTour1 = 0;
        GameManager.player2scoreTour1 = 0;
        GameManager.player3scoreTour1 = 0;
        GameManager.player4scoreTour1 = 0;

        GameManager.player1scoreTour2 = 0;
        GameManager.player2scoreTour2 = 0;
        GameManager.player3scoreTour2 = 0;
        GameManager.player4scoreTour2 = 0;

        GameManager.player1scoreTour3 = 0;
        GameManager.player2scoreTour3 = 0;
        GameManager.player3scoreTour3 = 0;
        GameManager.player4scoreTour3 = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
