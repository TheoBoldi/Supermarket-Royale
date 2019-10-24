using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingCartScript : MonoBehaviour
{
    private GameManager _gameManager;
    private GameObject cart_GO;
    public GameManager.Cart cart = new GameManager.Cart(100f, new List<GameManager.GameItem>(4));
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GetComponent<GameManager>();
        cart_GO = gameObject;
    }

    public void PlaceInCart(int cartSlotSelcted, GameManager.GameItem itemToPlace)
        {
            itemToPlace.isInCart = true;
            itemToPlace.cartSlotPosition = cartSlotSelcted;
            cart.cartStorage[cartSlotSelcted] = itemToPlace;
        }

    public GameManager.GameItem RemoveFromCart(int cartSlotSelected)
    {
        GameManager.GameItem itemToReturn;
        cart.cartStorage[cartSlotSelected].isInCart = false;
        cart.cartStorage[cartSlotSelected].cartSlotPosition = -1;
        itemToReturn = cart.cartStorage[cartSlotSelected];
        cart.cartStorage[cartSlotSelected] = new GameManager.GameItem(GameManager.GameItem.ItemType.Empty, GameManager.GameItem.ScoreCount.Empty, 1);
        return itemToReturn;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
