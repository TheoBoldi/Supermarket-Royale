using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreRecap : MonoBehaviour
{

    public Text player1scoreTour1;
    public Text player2scoreTour1;
    public Text player3scoreTour1;
    public Text player4scoreTour1;

    public Text player1scoreTour2;
    public Text player2scoreTour2;
    public Text player3scoreTour2;
    public Text player4scoreTour2;

    public Text player1scoreTour3;
    public Text player2scoreTour3;
    public Text player3scoreTour3;
    public Text player4scoreTour3;

    public Text player1scoreTour4;
    public Text player2scoreTour4;
    public Text player3scoreTour4;
    public Text player4scoreTour4;

    public Text player1scoreTour5;
    public Text player2scoreTour5;
    public Text player3scoreTour5;
    public Text player4scoreTour5;

    public Text player1scoreTour6;
    public Text player2scoreTour6;
    public Text player3scoreTour6;
    public Text player4scoreTour6;

    public GameObject p1win;
    public GameObject p2win;
    public GameObject p3win;
    public GameObject p4win;

    public GameObject Cadre1;
    public GameObject Cadre2;
    public GameObject Cadre3;
    public GameObject Cadre4;
    public GameObject Cadre5;
    public GameObject Cadre6;

    /*private void Awake()
    {
        player1scoreTour1 = GameObject.Find("Nv1_P1").GetComponentInChildren<Text>();
        player2scoreTour1 = GameObject.Find("Nv1_P2").GetComponentInChildren<Text>();
        player3scoreTour1 = GameObject.Find("Nv1_P3").GetComponentInChildren<Text>();
        player4scoreTour1 = GameObject.Find("Nv1_P4").GetComponentInChildren<Text>();

        player1scoreTour2 = GameObject.Find("Nv2_P1").GetComponentInChildren<Text>();
        player2scoreTour2 = GameObject.Find("Nv2_P2").GetComponentInChildren<Text>();
        player3scoreTour2 = GameObject.Find("Nv2_P3").GetComponentInChildren<Text>();
        player4scoreTour2 = GameObject.Find("Nv2_P4").GetComponentInChildren<Text>();

        player1scoreTour3 = GameObject.Find("Nv3_P1").GetComponentInChildren<Text>();
        player2scoreTour3 = GameObject.Find("Nv3_P2").GetComponentInChildren<Text>();
        player3scoreTour3 = GameObject.Find("Nv3_P3").GetComponentInChildren<Text>();
        player4scoreTour3 = GameObject.Find("Nv3_P4").GetComponentInChildren<Text>();
    }*/

    public void Update()
    {
        player1scoreTour1.text = GameManager.player1scoreTour1.ToString();
        player2scoreTour1.text = GameManager.player2scoreTour1.ToString();
        player3scoreTour1.text = GameManager.player3scoreTour1.ToString();
        player4scoreTour1.text = GameManager.player4scoreTour1.ToString();

        player1scoreTour2.text = GameManager.player1scoreTour2.ToString();
        player2scoreTour2.text = GameManager.player2scoreTour2.ToString();
        player3scoreTour2.text = GameManager.player3scoreTour2.ToString();
        player4scoreTour2.text = GameManager.player4scoreTour2.ToString();

        player1scoreTour3.text = GameManager.player1scoreTour3.ToString();
        player2scoreTour3.text = GameManager.player2scoreTour3.ToString();
        player3scoreTour3.text = GameManager.player3scoreTour3.ToString();
        player4scoreTour3.text = GameManager.player4scoreTour3.ToString();

        player1scoreTour4.text = GameManager.player1scoreTour4.ToString();
        player2scoreTour4.text = GameManager.player2scoreTour4.ToString();
        player3scoreTour4.text = GameManager.player3scoreTour4.ToString();
        player4scoreTour4.text = GameManager.player4scoreTour4.ToString();

        player1scoreTour5.text = GameManager.player1scoreTour5.ToString();
        player2scoreTour5.text = GameManager.player2scoreTour5.ToString();
        player3scoreTour5.text = GameManager.player3scoreTour5.ToString();
        player4scoreTour5.text = GameManager.player4scoreTour5.ToString();

        player1scoreTour6.text = GameManager.player1scoreTour6.ToString();
        player2scoreTour6.text = GameManager.player2scoreTour6.ToString();
        player3scoreTour6.text = GameManager.player3scoreTour6.ToString();
        player4scoreTour6.text = GameManager.player4scoreTour6.ToString();

        if (GameManager.p1Won)
        {
            p1win.SetActive(true);
        }
        if (GameManager.p2Won)
        {
            p2win.SetActive(true);
        }
        if (GameManager.p3Won)
        {
            p3win.SetActive(true);
        }
        if (GameManager.p4Won)
        {
            p4win.SetActive(true);
        }
    }

    public void CadreUI()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Cadre1.SetActive(true);
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Cadre2.SetActive(true);
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Cadre3.SetActive(true);
        }

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Cadre4.SetActive(true);
        }

        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Cadre5.SetActive(true);
        }

        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            Cadre6.SetActive(true);
        }
    }
    
}
