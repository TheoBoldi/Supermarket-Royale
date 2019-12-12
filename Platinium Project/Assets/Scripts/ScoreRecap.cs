using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }
}
