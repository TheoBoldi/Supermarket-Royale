using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour
{
    public Animator animator;
    public PlayerEntity entity;
    public ItemGrab itemGrab;
    public GameObject StarFall;

    public float timer = 1.0f;
    public bool p2pCol;

    public float recenColTimer = 2.0f;
    public bool recentCollision;
 
    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponent<PlayerEntity>();
        itemGrab = GetComponentInChildren<ItemGrab>();
    }

    // Update is called once per frame
    void Update()
    {
        if (p2pCol)
        {
            P2PCollision();
        }

        if (recentCollision)
        {
            recenColTimer -= Time.deltaTime;
            if(recenColTimer <= 0f)
            {
                recenColTimer = 2.0f;
                recentCollision = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!p2pCol && !recentCollision)
        {
            if (collision.gameObject.name.Contains("Player") && !entity.haveCaddie)
            {
                Debug.Log("collision player-player");
                p2pCol = true;
            }
        }
    }

    public void P2PCollision()
    {
        //Stoper le player.move pour 1 sec
        entity.StopMove();
        if(itemGrab.item != null && itemGrab.haveItem)
        {
            itemGrab.ItemDroping();
        }
        //Jouer l'animation de chute
        animator.SetBool("Fall", true);
        StarFall.SetActive(true);
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            animator.SetBool("Fall", false);
            StarFall.SetActive(false);
            entity.RestartMove();
            p2pCol = false;
            timer = 1.0f;
            recentCollision = true;
        }
    }
}
