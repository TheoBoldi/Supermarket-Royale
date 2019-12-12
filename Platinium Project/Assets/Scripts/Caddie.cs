using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caddie : MonoBehaviour
{ 
    public float cartHP = 100f;
    public List<GameItem.ItemType> cartStorage;
    private GameItem _gameItem;
    public void PlaceInCart(GameItem itemtoPlace,int cartSlotSelcted)
    {
        itemtoPlace.isInCart = true;
        itemtoPlace.cartSlotPosition = cartSlotSelcted;
        cartStorage[cartSlotSelcted] = itemtoPlace.ID;
    }
    public void RemoveFromCart(int cartSlotSelcted)
    {
        cartStorage[cartSlotSelcted] = GameItem.ItemType.Empty;
    }
    public void ClearCart()
    {
        cartStorage[0] = GameItem.ItemType.Empty;
        cartStorage[1] = GameItem.ItemType.Empty;
        cartStorage[2] = GameItem.ItemType.Empty;
        cartStorage[3] = GameItem.ItemType.Empty;

        Destroy(this.gameObject.transform.GetChild(2).GetChild(0).gameObject);
        Destroy(this.gameObject.transform.GetChild(3).GetChild(0).gameObject);
        Destroy(this.gameObject.transform.GetChild(4).GetChild(0).gameObject);
        Destroy(this.gameObject.transform.GetChild(5).GetChild(0).gameObject);
    }
}
