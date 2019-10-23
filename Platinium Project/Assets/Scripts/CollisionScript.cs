using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public Animation anim;
 
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
        if (collision.gameObject.name.Contains("Player"))
        {
            Debug.Log("collision player-player");
            //P2PCollision();
        }
    }

    public void P2PCollision()
    {
        //Stoper le player.move pour 1 sec
        //Jouer l'animation de chute
        //Reactiver le player.move
    }
}
