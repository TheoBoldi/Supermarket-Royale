using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caddie : MonoBehaviour
{ 
    public float cartHP = 100f;
    public List<GameItem> cartStorage;
    public GameItem gameItem;
    public void PlaceInCart(GameItem itemtoPlace,int cartSlotSelcted)
    {
        itemtoPlace.isInCart = true;
        itemtoPlace.cartSlotPosition = cartSlotSelcted;
        cartStorage[cartSlotSelcted] = itemtoPlace;
    }
    public GameItem RemoveFromCart(int cartSlotSelcted)
    {
        GameItem gameItemToReturn = cartStorage[cartSlotSelcted];
        cartStorage[cartSlotSelcted] = null;
        gameItemToReturn.cartSlotPosition = 0;
        gameItemToReturn.isInCart = false;
        return gameItemToReturn;
    }
    // Start is called before the first frame update
    void Start()
    {
        cartStorage = new List<GameItem>(4);
        gameItem = GetComponent<GameItem>();
        if(cartStorage != null)
        {
            cartStorage.Add(gameItem.CreateGameItem(GameItem.ItemType.Empty));
            cartStorage.Add(gameItem.CreateGameItem(GameItem.ItemType.Empty));
            cartStorage.Add(gameItem.CreateGameItem(GameItem.ItemType.Empty));
            cartStorage.Add(gameItem.CreateGameItem(GameItem.ItemType.Empty));
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }
}
