using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    //GameLogicManager for Super Market Royale by Dorian Gélas 2019-2020
    public bool isDebug = false;
    private ListListener _listListener;
    private bool p1Won;
    private bool p2Won;
    private bool p3Won;
    private bool p4Won;
    private CheckOutScript _checkoutscript;
    #region VariablesScore
    [Header("Score Values")]
    public int player1Score = 0;
    public int player2Score = 0;
    public int player3Score = 0;
    public int player4Score = 0;
    #endregion
    #region ListeObjectif
    [Header("Required Item List")]
    public List<GameItem.ItemType> player1Itemlist;
    public List<GameItem.ItemType> player2Itemlist;
    public List<GameItem.ItemType> player3Itemlist;
    public List<GameItem.ItemType> player4Itemlist;
    [HideInInspector]
    public GUIStyle guiSKIN;
    private string itemList;
    #endregion
    public void GenerateItemLists(List<GameItem.ItemType> listToGenrate)
    {
        listToGenrate.Clear();
        List<GameItem.ItemType> itemIgnoreList = new List<GameItem.ItemType>();
        GameItem.ItemType generatedGameItem;
        while (listToGenrate.Count < 4)
        {
            generatedGameItem = (GameItem.ItemType)((int)UnityEngine.Random.Range(1, 13));
            if (!itemIgnoreList.Contains(generatedGameItem)) {
                listToGenrate.Add(generatedGameItem);
                itemIgnoreList.Add(generatedGameItem);
            }
        }
        _listListener.UpdateUI();
    }

    void Awake()
    {
        _listListener = GameObject.Find("GAME_UI").GetComponent<ListListener>();
        //End of all GameItems
        guiSKIN.fontSize = 20;
        guiSKIN.normal.textColor = new Color(255.0f, 0.0f, 0.0f, 1.0f);
        
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
                    p1Won = true;
                    Debug.Log("Player 1 has Validated his item list");
                }
                break;
            case 2:
                {
                    p2Won = true;
                    Debug.Log("Player 2 has Validated his item list");
                }
                break;
            case 3:
                {
                    p3Won = true;
                    Debug.Log("Player 3 has Validated his item list");
                }
                break;
            case 4:
                {
                    p4Won = true;
                    Debug.Log("Player 4 has Validated his item list");
                }
                break;
        }
    }
    public bool CheckCart(List<GameItem.ItemType> listToCheck, int playerToCheck)
    {
        if (listToCheck.Count == 4)
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
    private void Update()
    {
        SysShortcuts();
    }
    public void SysShortcuts()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
