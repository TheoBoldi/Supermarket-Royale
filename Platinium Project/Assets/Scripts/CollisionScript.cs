using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public Animation anim;
    public PlayerEntity entity;
    public float timer = 1.0f;
    public bool p2pCol;
 
    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponent<PlayerEntity>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p2pCol)
        {
            P2PCollision();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            Debug.Log("collision player-player");
            p2pCol = true;
        }
    }

    public void P2PCollision()
    {
        //Stoper le player.move pour 1 sec
        entity.StopMove();
        //Jouer l'animation de chute

        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            entity.RestartMove();
            p2pCol = false;
            timer = 1.0f;
        }
    }
}
