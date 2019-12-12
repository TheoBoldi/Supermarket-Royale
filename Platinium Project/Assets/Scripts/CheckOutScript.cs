using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOutScript : MonoBehaviour
{
    private Caddie _caddie;
    private GameManager _gamemanager;
    public void CheckOut(Caddie cartToCheck, int playerNumber)
    {
        if (_gamemanager.CheckCart(cartToCheck.cartStorage, playerNumber))
        {
            _gamemanager.ValidateList(playerNumber);
            cartToCheck.ClearCart();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Caddie") && other.transform.root.gameObject.name.Contains("PlayerEntity"))
        {
            Debug.Log(other.transform.root.gameObject.name + "has entered checkin area");
            Caddie cartToCheck = other.GetComponent<Caddie>();
            int playerNumber;
            string nameofentity = other.transform.root.gameObject.name;
            string s = "PlayerEntity";
            nameofentity = nameofentity.Replace(s, "");
            switch (nameofentity)
            {
                case "1":
                    playerNumber = 1;
                    break;
                case "2":
                    playerNumber = 2;
                    break;
                case "3":
                    playerNumber = 3;
                    break;
                case "4":
                    playerNumber = 4;
                    break;
                default:
                    {
                        playerNumber = 0;
                        Debug.LogError("Could not detect Player Checking in");
                    }
                    break;
            }
            if (playerNumber > 0)
            {
                Debug.Log(other.transform.root.gameObject.name + "has tried to check in");
                CheckOut(cartToCheck, playerNumber);
            }
        }
    }

    private void Awake()
    {
        _gamemanager = GameObject.Find("EventSystem").GetComponent<GameManager>();
    }
}
