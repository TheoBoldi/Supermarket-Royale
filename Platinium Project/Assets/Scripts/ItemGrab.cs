using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrab : MonoBehaviour
{
    public GameObject item;
    public Transform itemPos;
    public DetectionScript detection;
    public bool haveItem = false;
    public bool canDropItemInCart = false;
    
    // Start is called before the first frame update
    void Start()
    {
        detection = GetComponent<DetectionScript>();
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
            item.GetComponent<MeshCollider>().enabled = false;
            item.transform.position = itemPos.transform.position;
            item.transform.rotation = itemPos.transform.rotation;
            item.transform.parent = itemPos;
            haveItem = true;
        }
    }

    public void ItemDroping()
    {
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.GetComponent<MeshCollider>().enabled = true;
        haveItem = false;
        item = null;
    }

    public void DropItemInCart()
    {
        if(detection.itemInCartPos1 != null && detection.itemInCartPos2 != null && detection.itemInCartPos3 != null && detection.itemInCartPos4 != null)
        {
            if (detection.itemInCartPos1.childCount < 1)
            {
                haveItem = false;
                item.transform.position = detection.itemInCartPos1.transform.position;
                item.transform.rotation = detection.itemInCartPos1.transform.rotation;
                item.transform.parent = detection.itemInCartPos1;
                item.transform.localScale = new Vector3((item.transform.lossyScale.x / 2), (item.transform.lossyScale.y / 2), (item.transform.lossyScale.z / 2));
                item = null;
            }
            else if (detection.itemInCartPos2.childCount < 1)
            {
                haveItem = false;
                item.transform.position = detection.itemInCartPos2.transform.position;
                item.transform.rotation = detection.itemInCartPos2.transform.rotation;
                item.transform.parent = detection.itemInCartPos2;
                item.transform.localScale = new Vector3((item.transform.lossyScale.x / 2), (item.transform.lossyScale.y / 2), (item.transform.lossyScale.z / 2));
                item = null;
            }
            else if (detection.itemInCartPos3.childCount < 1)
            {
                haveItem = false;
                item.transform.position = detection.itemInCartPos3.transform.position;
                item.transform.rotation = detection.itemInCartPos3.transform.rotation;
                item.transform.parent = detection.itemInCartPos3;
                item.transform.localScale = new Vector3((item.transform.lossyScale.x / 2), (item.transform.lossyScale.y / 2), (item.transform.lossyScale.z / 2));
                item = null;
            }
            else if (detection.itemInCartPos4.childCount < 1)
            {
                haveItem = false;
                item.transform.position = detection.itemInCartPos4.transform.position;
                item.transform.rotation = detection.itemInCartPos4.transform.rotation;
                item.transform.parent = detection.itemInCartPos4;
                item.transform.localScale = new Vector3((item.transform.lossyScale.x / 2), (item.transform.lossyScale.y / 2), (item.transform.lossyScale.z / 2));
                item = null;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            if (!haveItem)
            {
                item = other.gameObject;
            }
        }
        else if (other.gameObject.CompareTag("Caddie"))
        {
            canDropItemInCart = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            item = null;
        }
        else if (other.gameObject.CompareTag("Caddie"))
        {
            canDropItemInCart = false;
        }
    }
}
