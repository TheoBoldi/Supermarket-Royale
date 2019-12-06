using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOutScript : MonoBehaviour
{
    public GameManager _gamemanager;
        public void CheckOut(Caddie cartToCheck, int playerNumber)
        {
            if (_gamemanager.CheckCart(cartToCheck.cartStorage, playerNumber))
            {
                _gamemanager.ValidateList(playerNumber);
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

    private void Awake()
    {
        _gamemanager = GetComponent<GameManager>();
    }
}
