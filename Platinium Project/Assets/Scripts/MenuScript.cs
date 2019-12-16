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

        GameManager.player1scoreTour4 = 0;
        GameManager.player2scoreTour4 = 0;
        GameManager.player3scoreTour4 = 0;
        GameManager.player4scoreTour4 = 0;

        GameManager.player1scoreTour5 = 0;
        GameManager.player2scoreTour5 = 0;
        GameManager.player3scoreTour5 = 0;
        GameManager.player4scoreTour5 = 0;

        GameManager.player1scoreTour6 = 0;
        GameManager.player2scoreTour6 = 0;
        GameManager.player3scoreTour6 = 0;
        GameManager.player4scoreTour6 = 0;

        GameManager.p1Won = false;
        GameManager.p2Won = false;
        GameManager.p3Won = false;
        GameManager.p4Won = false;
    }



    public void QuitGame()
    {
        Application.Quit();
    }
}
