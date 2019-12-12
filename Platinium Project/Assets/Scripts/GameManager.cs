using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //GameLogicManager for Super Market Royale by Dorian Gélas 2019-2020
    public bool isDebug = false;
    private UIListener _UIListener;
    private bool p1Won;
    private bool p2Won;
    private bool p3Won;
    private bool p4Won;
    private CheckOutScript _checkoutscript;
    private float time;
    private int sequenceP1index = 0;
    private int sequenceP2index = 0;
    private int sequenceP3index = 0;
    private int sequenceP4index = 0;
    #region VariablesScore
    [Header("Score Values")]
    public int ptsPerList = 1;
    public int player1Score = 0;
    public int player2Score = 0;
    public int player3Score = 0;
    public int player4Score = 0;

    public static int player1scoreTour1 = 0;
    public static int player2scoreTour1 = 0;
    public static int player3scoreTour1 = 0;
    public static int player4scoreTour1 = 0;

    public static int player1scoreTour2 = 0;
    public static int player2scoreTour2 = 0;
    public static int player3scoreTour2 = 0;
    public static int player4scoreTour2 = 0;

    public static int player1scoreTour3 = 0;
    public static int player2scoreTour3 = 0;
    public static int player3scoreTour3 = 0;
    public static int player4scoreTour3 = 0;

    #endregion
    #region ListeObjectif
    [Header("Required Item List")]
    public List<GameItem.ItemType> player1Itemlist;
    public List<GameItem.ItemType> player2Itemlist;
    public List<GameItem.ItemType> player3Itemlist;
    public List<GameItem.ItemType> player4Itemlist;
    private List<GameItem.ItemType>[] sequenceP1;
    private List<GameItem.ItemType>[] sequenceP2;
    private List<GameItem.ItemType>[] sequenceP3;
    private List<GameItem.ItemType>[] sequenceP4;
    [HideInInspector]
    public GUIStyle guiSKIN;
    private string itemList;
    #endregion

    public AudioSource listevalidee;


    public void GenerateItemLists(List<GameItem.ItemType> listToGenrate)
    {
        listToGenrate.Clear();
        List<GameItem.ItemType> itemIgnoreList = new List<GameItem.ItemType>();
        GameItem.ItemType generatedGameItem;
        while (listToGenrate.Count < 3)
        {
            generatedGameItem = (GameItem.ItemType)((int)UnityEngine.Random.Range(1, 21));
            if (!itemIgnoreList.Contains(generatedGameItem)) {
                listToGenrate.Add(generatedGameItem);
                itemIgnoreList.Add(generatedGameItem);
            }
        }
        _UIListener.UpdateUI();
    }
    void Awake()
    {
        _UIListener = GameObject.Find("GAME_UI").GetComponent<UIListener>();
        //End of all GameItems
        guiSKIN.fontSize = 20;
        guiSKIN.normal.textColor = new Color(255.0f, 0.0f, 0.0f, 1.0f);

        sequenceP1 = new List<GameItem.ItemType>[4];
        sequenceP2 = new List<GameItem.ItemType>[4];
        sequenceP3 = new List<GameItem.ItemType>[4];
        sequenceP4 = new List<GameItem.ItemType>[4];

        sequenceP1[0] = new List<GameItem.ItemType>(3);
        sequenceP1[1] = new List<GameItem.ItemType>(3);
        sequenceP1[2] = new List<GameItem.ItemType>(3);
        sequenceP1[3] = new List<GameItem.ItemType>(3);

        sequenceP2[0] = new List<GameItem.ItemType>(3);
        sequenceP2[1] = new List<GameItem.ItemType>(3);
        sequenceP2[2] = new List<GameItem.ItemType>(3);
        sequenceP2[3] = new List<GameItem.ItemType>(3);

        sequenceP3[0] = new List<GameItem.ItemType>(3);
        sequenceP3[1] = new List<GameItem.ItemType>(3);
        sequenceP3[2] = new List<GameItem.ItemType>(3);
        sequenceP3[3] = new List<GameItem.ItemType>(3);

        sequenceP4[0] = new List<GameItem.ItemType>(3);
        sequenceP4[1] = new List<GameItem.ItemType>(3);
        sequenceP4[2] = new List<GameItem.ItemType>(3);
        sequenceP4[3] = new List<GameItem.ItemType>(3);

        sequenceP1[0].Add(GameItem.ItemType.Fish);
        sequenceP1[0].Add(GameItem.ItemType.Egg);
        sequenceP1[0].Add(GameItem.ItemType.Turnip);
        //sequenceP1[0].Add(GameItem.ItemType.Cheese);

        sequenceP1[1].Add(GameItem.ItemType.Milk);
        sequenceP1[1].Add(GameItem.ItemType.Mushroom);
        sequenceP1[1].Add(GameItem.ItemType.Yoghurt);
        //sequenceP1[1].Add(GameItem.ItemType.Cherry);

        sequenceP1[2].Add(GameItem.ItemType.Leek);
        sequenceP1[2].Add(GameItem.ItemType.Fish);
        sequenceP1[2].Add(GameItem.ItemType.Chicken_Leg);
        //sequenceP1[2].Add(GameItem.ItemType.Cheese);

        sequenceP2[0].Add(GameItem.ItemType.Fish);
        sequenceP2[0].Add(GameItem.ItemType.Mushroom);
        sequenceP2[0].Add(GameItem.ItemType.Chicken_Leg);
        //sequenceP2[0].Add(GameItem.ItemType.Cherry);

        sequenceP2[1].Add(GameItem.ItemType.Pear);
        sequenceP2[1].Add(GameItem.ItemType.Beef_Steak);
        sequenceP2[1].Add(GameItem.ItemType.Sushi);
        //sequenceP2[1].Add(GameItem.ItemType.Turnip);

        sequenceP2[2].Add(GameItem.ItemType.Chicken_Leg);
        sequenceP2[2].Add(GameItem.ItemType.Pear);
        sequenceP2[2].Add(GameItem.ItemType.Banana);
        //sequenceP2[2].Add(GameItem.ItemType.Cherry);

        sequenceP3[0].Add(GameItem.ItemType.Cherry);
        sequenceP3[0].Add(GameItem.ItemType.Beef_Steak);
        sequenceP3[0].Add(GameItem.ItemType.Milk);
        //sequenceP3[0].Add(GameItem.ItemType.Coconut);

        sequenceP3[1].Add(GameItem.ItemType.Carrot);
        sequenceP3[1].Add(GameItem.ItemType.Fish);
        sequenceP3[1].Add(GameItem.ItemType.Cherry);
        //sequenceP3[1].Add(GameItem.ItemType.Coconut);

        sequenceP3[2].Add(GameItem.ItemType.Beef_Steak);
        sequenceP3[2].Add(GameItem.ItemType.Pear);
        sequenceP3[2].Add(GameItem.ItemType.Leek);
        //sequenceP3[2].Add(GameItem.ItemType.Chicken_Leg);

        sequenceP4[0].Add(GameItem.ItemType.Coconut);
        sequenceP4[0].Add(GameItem.ItemType.Carrot);
        sequenceP4[0].Add(GameItem.ItemType.Sushi);
        //sequenceP4[0].Add(GameItem.ItemType.Kiwi);

        sequenceP4[1].Add(GameItem.ItemType.Egg);
        sequenceP4[1].Add(GameItem.ItemType.Milk);
        sequenceP4[1].Add(GameItem.ItemType.Chicken_Leg);
        //sequenceP4[1].Add(GameItem.ItemType.Pear);

        sequenceP4[2].Add(GameItem.ItemType.Cherry);
        sequenceP4[2].Add(GameItem.ItemType.Mushroom);
        sequenceP4[2].Add(GameItem.ItemType.Turnip);
        //sequenceP4[2].Add(GameItem.ItemType.Cherry);

        sequenceP1[3] = sequenceP4[0];
        sequenceP2[3] = sequenceP1[0];
        sequenceP3[3] = sequenceP2[0];
        sequenceP4[3] = sequenceP3[0];

        player1Itemlist = sequenceP1[0];
        player2Itemlist = sequenceP2[0];
        player3Itemlist = sequenceP3[0];
        player4Itemlist = sequenceP4[0];

        _UIListener.UpdateUI();
    }
    void OnGUI()
    {
        if (isDebug)
        {
            GUI.Label(new Rect(10.0f, Screen.height - 25.0f, 1000.0f, Screen.width), itemList, guiSKIN);
        }
        if (p1Won) 
        {
            GUI.Label(new Rect(10.0f, 10.0f, 900.0f, Screen.width), "Player 1 Completed his list", guiSKIN);
        }
        if (p2Won)
        {
            GUI.Label(new Rect(10.0f, 30.0f, 900.0f, Screen.width), "Player 2 Completed his list", guiSKIN);
        }
        if (p3Won)
        {
            GUI.Label(new Rect(10.0f, 50.0f, 900.0f, Screen.width), "Player 3 Completed his list", guiSKIN);
        }
        if (p4Won)
        {
            GUI.Label(new Rect(10.0f, 70.0f, 900.0f, Screen.width), "Player 4 Completed his list", guiSKIN);
        }
    }
    public void ValidateList(int playerWhoValidated)
    {
        switch (playerWhoValidated)
        {
            case 1:
                {
                    sequenceP1index++;
                    if(sequenceP1index == 4)
                    {
                        sequenceP1index = 0;
                    }
                    player1Itemlist = sequenceP1[sequenceP1index];
                    player1Score += ptsPerList;
                    _UIListener.UpdateUI();
                    Debug.Log("Player 1 has Validated his item list");
                    SoundManager.instance.CheckoutSound();
                }
                break;
            case 2:
                {
                    sequenceP2index++;
                    if (sequenceP2index == 4)
                    {
                        sequenceP2index = 0;
                    }
                    player2Itemlist = sequenceP2[sequenceP2index];
                    player2Score += ptsPerList;
                    _UIListener.UpdateUI();
                    Debug.Log("Player 2 has Validated his item list");
                    SoundManager.instance.CheckoutSound();
                }
                break;
            case 3:
                {
                    sequenceP3index++;
                    if (sequenceP3index == 4)
                    {
                        sequenceP3index = 0;
                    }
                    player3Itemlist = sequenceP3[sequenceP3index];
                    player3Score += ptsPerList;
                    _UIListener.UpdateUI();
                    Debug.Log("Player 3 has Validated his item list");
                    SoundManager.instance.CheckoutSound();
                }
                break;
            case 4:
                {
                    sequenceP4index++;
                    if (sequenceP4index == 4)
                    {
                        sequenceP4index = 0;
                    }
                    player4Itemlist = sequenceP4[sequenceP4index];
                    player4Score += ptsPerList;
                    _UIListener.UpdateUI();
                    Debug.Log("Player 4 has Validated his item list");
                    SoundManager.instance.CheckoutSound();
                }
                break;
        }
    }
    public bool CheckCart(List<GameItem.ItemType> listToCheck, int playerToCheck)
    {
        if (listToCheck.Count == 3)
        {
            //Check-in Process
            if (playerToCheck == 1)
            {
                return listToCheck.TrueForAll(x => CompareItems(x, player1Itemlist));
            }
            else if (playerToCheck == 2)
            {
                return listToCheck.TrueForAll(x => CompareItems(x, player2Itemlist));
            }
            else if (playerToCheck == 3)
            {
                return listToCheck.TrueForAll(x => CompareItems(x, player3Itemlist));
            }
            else if (playerToCheck == 4)
            {
                return listToCheck.TrueForAll(x => CompareItems(x, player4Itemlist));
            }
            else
            {
                return false;
            }
        }
        return false;
    }
    public bool CompareItems(GameItem.ItemType itemtoCheck, List<GameItem.ItemType> checkList)
    {
        return checkList.Contains(itemtoCheck);
    }
    public void SelectWinner()
    {
        if(time >= 120.0f)
        {
            Time.timeScale = 0;
            if (player1Score > player2Score && player1Score > player3Score && player1Score > player4Score)
            {
                p1Won = true;
            }
            else if (player2Score > player1Score && player2Score > player3Score && player2Score > player4Score)
            {
                p2Won = true;
            }
            else if (player3Score > player1Score && player3Score > player2Score && player3Score > player4Score)
            {
                p3Won = true;
            }
            else if (player4Score > player1Score && player4Score > player3Score && player4Score > player2Score)
            {
                p4Won = true;
            }
        }
    }
    private void Update()
    {
        //SysShortcuts();
        time += Time.deltaTime;

        if (SceneManager.GetActiveScene().name.Contains("1"))
        {
            player1scoreTour1 = player1Score;
            player2scoreTour1 = player2Score;
            player3scoreTour1 = player3Score;
            player4scoreTour1 = player4Score;
        }

        if (SceneManager.GetActiveScene().name.Contains("2"))
        {
            player1scoreTour2 = player1Score + player1scoreTour1;
            player2scoreTour2 = player2Score + player2scoreTour1;
            player3scoreTour2 = player3Score + player3scoreTour1;
            player4scoreTour2 = player4Score + player4scoreTour1;
        }

        if (SceneManager.GetActiveScene().name.Contains("3"))
        {
            player1scoreTour3 = player1Score + player1scoreTour2;
            player2scoreTour3 = player2Score + player2scoreTour2;
            player3scoreTour3 = player3Score + player3scoreTour2;
            player4scoreTour3 = player4Score + player4scoreTour2;
        }
    }

    /*public void SysShortcuts()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }*/
}
