using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public float timer = 5.0f;
    public bool isOnShelf = true;
    public GameObject item;

    private float scaleX;
    private float scaleY;
    private float scaleZ;

    public ParticleSystem smoke;

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
                ParticleSystem effect2 = Instantiate(smoke) as ParticleSystem;
                effect2.transform.position = this.transform.position;

                GameObject b = Instantiate(item) as GameObject;
                b.transform.GetChild(0).gameObject.SetActive(false);
                b.GetComponent<Rigidbody>().isKinematic = true;
                b.GetComponent<MeshCollider>().enabled = true;
                b.transform.position = this.transform.position;
                b.transform.rotation = this.transform.rotation;
                b.transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
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
            scaleX = item.transform.localScale.x;
            scaleY = item.transform.localScale.y;
            scaleZ = item.transform.localScale.z;
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
