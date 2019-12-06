using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public float timer = 5.0f;
    public bool isOnShelf = true;
    public GameObject item;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isOnShelf == false)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                GameObject b = Instantiate(item) as GameObject;
                b.GetComponent<Rigidbody>().isKinematic = true;
                b.transform.position = this.transform.position;
                b.transform.rotation = this.transform.rotation;
                isOnShelf = true;
                timer = 5.0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item") && item == null)
        {
            item = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ItemGrab>().itemPos.GetChild(0).name.Contains(item.name))
        {
            isOnShelf = false;
        }
    }
}
