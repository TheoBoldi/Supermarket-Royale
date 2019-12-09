using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaddieCollision : MonoBehaviour
{
    public ParticleSystem spark;

    private GameObject otherPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ya collision");
            otherPlayer = collision.gameObject;
            if (otherPlayer.GetComponent<CollisionScript>().entity.haveCaddie)
            {
                otherPlayer.GetComponent<CollisionScript>().entity.DropCaddie();
                otherPlayer.GetComponent<CollisionScript>().p2pCol = true;
                otherPlayer = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Caddie"))
        {
            Debug.Log("Collision Caddie-Caddie");
            //spark.Emit(1);
        }
    }
}
