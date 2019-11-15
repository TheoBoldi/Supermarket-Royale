using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public string itemList;
    #endregion
    /*public void GenerateItemLists(List<GameItem> listToGenrate)
    {
        listToGenrate.Clear();
        for (int selecteur = 0; selecteur > listToGenrate.Capacity; selecteur++)
        {
            listToGenrate[selecteur] = itemTotaList[Mathf.Clamp(((UnityEngine.Random.Range(0, itemsTotal))), 0, itemsTotal)];
        }
    }*/

    void Start()
    {
        //End of all GameItems
        player1Itemlist = new List<GameItem.ItemType>(4);
        player2Itemlist = new List<GameItem.ItemType>(4);
        player3Itemlist = new List<GameItem.ItemType>(4);
        player4Itemlist = new List<GameItem.ItemType>(4);
        guiSKIN.fontSize = 20;
        guiSKIN.normal.textColor = new Color(255.0f, 0.0f, 0.0f, 1.0f);
        foreach(string s in Enum.GetNames(typeof(GameItem.ItemType)))
        {
            itemList += (s + " ");
        }
        player1Itemlist.Add(GameItem.ItemType.Fish);
        player1Itemlist.Add(GameItem.ItemType.Egg);
        player1Itemlist.Add(GameItem.ItemType.Turnip);
        player1Itemlist.Add(GameItem.ItemType.Cheese);
        player2Itemlist.Add(GameItem.ItemType.Fish);
        player2Itemlist.Add(GameItem.ItemType.Mushroom);
        player2Itemlist.Add(GameItem.ItemType.Chicken_Leg);
        player2Itemlist.Add(GameItem.ItemType.Cherry);
        player3Itemlist.Add(GameItem.ItemType.Cherry);
        player3Itemlist.Add(GameItem.ItemType.Beef_Steak);
        player3Itemlist.Add(GameItem.ItemType.Milk);
        player3Itemlist.Add(GameItem.ItemType.Coconut);
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
    public bool CheckCart(List<GameItem> listToCheck, int playerToCheck)
    {
        if (listToCheck.Count == 4)
        {
            //Check-in Process
            if (playerToCheck == 1)
            {
                return listToCheck.TrueForAll(x => CompareItems(x.ID, player1Itemlist));
            }
            else if (playerToCheck == 2)
            {
                return listToCheck.TrueForAll(x => CompareItems(x.ID, player2Itemlist));
            }
            else if (playerToCheck == 3)
            {
                return listToCheck.TrueForAll(x => CompareItems(x.ID, player3Itemlist));
            }
            else if (playerToCheck == 4)
            {
                return listToCheck.TrueForAll(x => CompareItems(x.ID, player4Itemlist));
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
        foreach (Caddie caddie in GetComponents<Caddie>())
        {
            _checkoutscript.CheckOut(caddie, 1);
            _checkoutscript.CheckOut(caddie, 2);
            _checkoutscript.CheckOut(caddie, 3);
        }
    }
}
