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
        public enum ItemType {Empty = 0, Chips = 1, Soda = 2, Water = 3, Meat = 4, DebugTrue = -1, DebugFalse = -2};
        public enum ScoreCount {Empty = 0, Small = 10, Medium = 50, Big = 200, THICCDebug = 1000, smoleDebug = 1};
        public ItemType itemType;
        public ScoreCount score;
        [Range(1, 10)]
        public int durationOfGrab;
        [System.NonSerialized]
        public bool isInCart = false;
        [System.NonSerialized]
        public int cartSlotPosition = -1;
        public GameItem(ItemType _itemType = ItemType.Empty, ScoreCount _score = ScoreCount.Empty, int _durationOfGrab = 1)
        {
            itemType = _itemType;
            score = _score;
            durationOfGrab = Mathf.Clamp(_durationOfGrab, 1, 10);
        }

    }
    [System.Serializable]
    public class Cart
    {
        public float cartHP = 100f;
        public List<GameItem> cartStorage;
        
        public Cart(float _startingHealth, List<GameItem> _startingList)
        {
            cartHP = _startingHealth;
            cartStorage = _startingList;
        }
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
    public List<GameItem.ItemType> player1Itemlist;
    public List<GameItem.ItemType> player2Itemlist;
    public List<GameItem.ItemType> player3Itemlist;
    public List<GameItem.ItemType> player4Itemlist;
    #endregion
    #region GestionObjets
    [Header("Item ID Managment")]
    [Range(1, 10)]
    public int itemsTotal = 3;
    public GameItem empty = new GameItem();
    public GameItem chips = new GameItem(GameItem.ItemType.Chips, GameItem.ScoreCount.Small, 1);
    public GameItem eau = new GameItem(GameItem.ItemType.Water, GameItem.ScoreCount.Small, 1);
    public GameItem meat = new GameItem(GameItem.ItemType.Meat, GameItem.ScoreCount.Big, 1);
    public GameItem cola = new GameItem(GameItem.ItemType.Chips, GameItem.ScoreCount.Medium, 1);
    public List<GameItem> itemTotaList;
    #endregion

    public void GenerateItemLists(List<GameItem.ItemType> listToGenrate)
    {
        listToGenrate.Clear();
        for (int selecteur = 0; selecteur > listToGenrate.Capacity; selecteur++)
        {
            listToGenrate[selecteur] = itemTotaList[Mathf.Clamp(UnityEngine.Random.Range(0, itemsTotal), 0, itemsTotal)].itemType;
        }
    }

    void Start()
    {
        //WARNING : Not adding all the available GameItems down below, at the start of the game, can cause errors
        itemTotaList = new List<GameItem>(itemsTotal);
        itemTotaList.Add(empty);
        itemTotaList.Add(chips);
        //End of all GameItems
        player1Itemlist = new List<GameItem.ItemType>(listSize);
        player2Itemlist = new List<GameItem.ItemType>(listSize);
        player3Itemlist = new List<GameItem.ItemType>(listSize);
        player4Itemlist = new List<GameItem.ItemType>(listSize);

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

    public bool CompareItems(GameItem itemtoCheck, List<GameItem.ItemType> checkList)
    {
        if (itemtoCheck.itemType == GameItem.ItemType.DebugTrue)
        {
            return true;
        }
        else if(itemtoCheck.itemType == GameItem.ItemType.DebugFalse)
        {
            return false;
        }
        else
        {
            return checkList.Contains(itemtoCheck.itemType);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
