using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //GameLogicManager for Super Market Royale by Dorian Gélas 2019-2020
    public bool isDebug;
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
    public GUIStyle guiSKIN;
    private string itemList;
    private string player1Itemliststr;
    private string player2Itemliststr;
    private string player3Itemliststr;
    private string player4Itemliststr;
    #endregion

    public void GenerateItemLists(List<GameItem.ItemType> listToGenrate)
    {
        listToGenrate.Clear();
        for (int selecteur = 0; selecteur <=4 ; selecteur++)
        {
            listToGenrate[selecteur] = (GameItem.ItemType)UnityEngine.Random.Range(0, 13);
        }
    }

    void Awake()
    {
        //End of all GameItems
        guiSKIN.fontSize = 20;
        guiSKIN.normal.textColor = new Color(255.0f, 0.0f, 0.0f, 1.0f);
        foreach (string s in Enum.GetNames(typeof(GameItem.ItemType)))
        {
            itemList += (s + " ");
        }
        foreach (string s in Enum.GetNames(typeof(GameItem.ItemType)))
        {
            player1Itemliststr += (s + " ");
        }
        foreach (string s in Enum.GetNames(typeof(GameItem.ItemType)))
        {
            player2Itemliststr += (s + " ");
        }
        foreach (string s in Enum.GetNames(typeof(GameItem.ItemType)))
        {
            player3Itemliststr += (s + " ");
        }
        foreach (string s in Enum.GetNames(typeof(GameItem.ItemType)))
        {
            player4Itemliststr += (s + " ");
        }
        player1Itemlist = new List<GameItem.ItemType>(4);
        player2Itemlist = new List<GameItem.ItemType>(4);
        player3Itemlist = new List<GameItem.ItemType>(4);
        player4Itemlist = new List<GameItem.ItemType>(4);
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
                }
                break;
            case 2:
                {
                    p2Won = true;
                }
                break;
            case 3:
                {
                    p3Won = true;
                }
                break;
            case 4:
                {
                    p4Won = true;
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
