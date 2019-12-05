using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ShoppingCartController : MonoBehaviour
{
    //Script par Théo

    public bool isNearCart;
    public bool cartIsUsed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!cartIsUsed)
        {
            this.gameObject.transform.parent.eulerAngles = new Vector3(0, this.gameObject.transform.parent.eulerAngles.y, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
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
            if (!cartIsUsed)
            {
                isNearCart = false;
            }
        }
    }
}
