using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOutScript : MonoBehaviour
{
    private GameManager _GameManager;

    public void CheckOut(Caddie cartToCheck, int playerNumber)
    {
        if (!cartToCheck.cartStorage.Contains(GameItem.ItemType.Empty))
        {
            if (_GameManager.CheckCart(cartToCheck.cartStorage, playerNumber))
            {
                _GameManager.ValidateList(playerNumber);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Caddie") && other.transform.root.gameObject.name.Contains("PlayerEntity"))
        {
            Caddie cartToCheck = other.GetComponent<Caddie>();
            int playerNumber;
            switch (other.transform.root.gameObject.tag)
            {
                case "Player 1":
                    playerNumber = 1;
                    break;
                case "Player 2":
                    playerNumber = 2;
                    break;
                case "Player 3":
                    playerNumber = 3;
                    break;
                case "Player 4":
                    playerNumber = 4;
                    break;
                default:
                    {
                        playerNumber = 0;
                        Debug.LogError("Could not detect Player Checking in");
                    }
                break;
            }
            CheckOut(cartToCheck, playerNumber);
        }
    }
}
