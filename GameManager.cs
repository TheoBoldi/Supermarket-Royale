using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //GameLogicManager for Super Market Royale by Dorian Gélas 2019-2020
   
    [System.Serializable]
    public class GameItem
    {
        public enum ItemType { Empty = 0, Chips = 1, Soda = 2, Water = 3, Meat = 4 };
        public ItemType ID;
        public int score;
        public float durationOfGrab;
        private bool isInCart = false;
        private int cartSlotPosition = 0;
        public GameItem(ItemType _id = ItemType.Empty, int _score = 0, float _durationOfGrab = 1f)
        {
            ID = _id;
            score = _score;
            durationOfGrab = _durationOfGrab;
        }

    }
    [System.Serializable]
    public class Cart
    {
        public float cartHP = 100f;
        private List<GameItem> cartStorage = new List<GameItem>(6);
        /*void PlaceInCart(int cartSlotSelcted)
        {
            isInCart = true;
            cartSlotPosition = cartSlotSelcted;
        }
    int RemoveFromCart()
    {
      isInCart = false;
      return cartSlotPosition;
    }*/
    }


    #region VariablesScore
    [Header("Score Values")]
    public int player1Score = 0;
    public int player2Score = 0;
    public int player3Score = 0;
    public int player4Score = 0;
    #endregion
    #region ListeObjectif
    [Header("Required Item List")]
    [Range(1, 4)]
    public int listSize = 3;
    public List<GameItem> player1Itemlist;
    public List<GameItem> player2Itemlist;
    public List<GameItem> player3Itemlist;
    public List<GameItem> player4Itemlist;
    #endregion
    #region GestionObjets
    [Header("Item ID Managment")]
    [Range(1, 10)]
    public int itemsTotal = 3;
    public GameItem empty = new GameItem();
    public GameItem chips = new GameItem(GameItem.ItemType.Chips, 10, 1);
    public GameItem eau = new GameItem(GameItem.ItemType.Water, 10, 1);
    public GameItem meat = new GameItem(GameItem.ItemType.Meat, 10, 1);
    public GameItem cola = new GameItem(GameItem.ItemType.Chips, 10, 1);
    public List<GameItem> itemTotaList;
    #endregion

    public void GenerateItemLists(List<GameItem> listToGenrate)
    {
        listToGenrate.Clear();
        for (int selecteur = 0; selecteur > listToGenrate.Capacity; selecteur++)
        {
            listToGenrate[selecteur] = itemTotaList[Mathf.Clamp(((UnityEngine.Random.Range(0, itemsTotal))), 0, itemsTotal)];
        }
    }

    void Start()
    {
        //WARNING : Not adding all the available GameItems down below, at the start of the game, can cause errors
        itemTotaList = new List<GameItem>(itemsTotal);
        itemTotaList.Add(empty);
        itemTotaList.Add(chips);
        //End of all GameItems
        player1Itemlist = new List<GameItem>(listSize);
        player2Itemlist = new List<GameItem>(listSize);
        player3Itemlist = new List<GameItem>(listSize);
        player4Itemlist = new List<GameItem>(listSize);

    }

    public bool CheckCart(List<GameItem> listToCheck, int playerToCheck)
    {
        
        //Check-in Process
        if(playerToCheck == 1)
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

    public bool CompareItems(GameItem itemtoCheck, List<GameItem> checkList)
    {
        return checkList.Contains(itemtoCheck);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
