using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOutScript : MonoBehaviour
{
    public GameManager _GameManager;

    public void CheckOut(Caddie cartToCheck, int playerNumber)
    {
        if (_GameManager.CheckCart(cartToCheck.cartStorage, playerNumber))
        {
            _GameManager.ValidateList(playerNumber);
        }
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Caddie" && Objet Parent == joueur)
        {
            Caddie cartToCheck = GetComponent<Caddie>();
            int playerNumber = 1; //Code pour déterminer quel joueur check sa liste;
            
        }
    }*/
}
