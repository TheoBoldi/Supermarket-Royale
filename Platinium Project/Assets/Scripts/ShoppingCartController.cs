﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ShoppingCartController : MonoBehaviour
{
    //Script par Théo

    public static bool isNearCart;
    public static bool cartIsUsed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearCart = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearCart = false;
        }
    }
}
