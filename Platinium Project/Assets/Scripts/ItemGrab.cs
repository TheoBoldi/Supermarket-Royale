using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrab : MonoBehaviour
{
    public GameObject item;
    public Transform itemPos;
    public bool haveItem = false;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemGrabing()
    {
        if(item != null)
        {
            item.GetComponent<Rigidbody>().isKinematic = true;
            item.transform.position = itemPos.transform.position;
            item.transform.rotation = itemPos.transform.rotation;
            item.transform.parent = itemPos;
            haveItem = true;
        }
    }

    public void ItemDroping()
    {
        item.transform.parent = null;
        item.GetComponent<Rigidbody>().isKinematic = false;
        haveItem = false;
        item = null;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Debug.Log("item en face");
            if (!haveItem)
            {
                item = other.gameObject;
            }
        }
    }
}
