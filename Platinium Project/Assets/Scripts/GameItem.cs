﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameItem : MonoBehaviour
{
    private float _scaleX;
    private float _scaleY;
    private float _scaleZ;

    private void Awake()
    {
        _scaleX = transform.lossyScale.x;
        _scaleY = transform.lossyScale.y;
        _scaleZ = transform.lossyScale.z;
    }

    private void Update()
    {
        transform.localScale = new Vector3(_scaleX, _scaleY, _scaleZ);
    }

    //GameLogic by Dorian Gélas 2019-2020
    #region Var
    public enum ItemType { Empty = 0, Fish = 1, Chicken_Leg = 2, Beef_Steak = 3, Turnip = 4, Egg = 5, Cheese = 6, Milk = 7, Coconut = 8, Stawberry = 9, Cherry = 10, Banana = 11, Mushroom = 12, Tomato = 13};
    public ItemType ID;
    public int score;
    public float durationOfGrab;
    public bool isInCart = false;
    public int cartSlotPosition = 0;
    #endregion
    private GameItem(ItemType _id, int _score = 0, float _durationOfGrab = 0f)
    {
        ID = _id;
        score = _score;
        durationOfGrab = _durationOfGrab;
    }
    public GameItem CreateGameItem(ItemType _id)
    {
        GameItem gameItemInstance;
        switch (_id)
        {
            case ItemType.Empty :
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Empty, 0, 0);
                }
            break;
            case ItemType.Banana:
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Banana, 0, 0);
                }
            break;
            case ItemType.Beef_Steak:
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Beef_Steak, 0, 0);
                }
            break;
            case ItemType.Cheese:
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Cheese, 0, 0);
                }
            break;
            case ItemType.Cherry:
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Cherry, 0, 0);
                }
            break;
            case ItemType.Chicken_Leg:
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Chicken_Leg, 0, 0);
                }
                break;
            case ItemType.Coconut:
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Coconut, 0, 0);
                }
                break;
            case ItemType.Egg:
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Egg, 0, 0);
                }
                break;
            case ItemType.Fish:
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Fish, 0, 0);
                }
                break;
            case ItemType.Milk:
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Milk, 0, 0);
                }
                break;
            case ItemType.Mushroom:
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Mushroom, 0, 0);
                }
                break;
            case ItemType.Stawberry:
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Stawberry, 0, 0);
                }
                break;
            case ItemType.Turnip:
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Turnip, 0, 0);
                }
                break;
            default :
                {
                    gameItemInstance = new GameItem(GameItem.ItemType.Empty, 0, 0);
                }
            break;
        }
        return gameItemInstance;
    }
}
