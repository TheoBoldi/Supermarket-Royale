using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class ShoppingCartController : MonoBehaviour
{
    //Script par Théo

    public static bool isNearCart;
    public static bool cartIsUsed;

    public GameObject player;
    public Transform nearestCaddie;
    private DetectionScript detection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cartIsUsed)
        {
            CartControls();
        }
        else
        {
            PlayerControls();
        }
    }

    public void PlayerControls()
    {
        PlayerEntity.acceleration = 100f;
        PlayerEntity.moveSpeedMax = 8f;
        PlayerEntity.friction = 100f;
        PlayerEntity.turnFriction = 0f;
        PlayerEntity.turnSpeed = 15f;
    }

    public void CartControls()
    {
        if(nearestCaddie != null)
        {
            nearestCaddie.transform.position = PlayerEntity.cartPos.position;
            nearestCaddie.transform.rotation = PlayerEntity.cartPos.rotation;
            PlayerEntity.acceleration = 10f;
            PlayerEntity.moveSpeedMax = 6.4f;
            PlayerEntity.friction = 10f;
            PlayerEntity.turnFriction = 20f;
            PlayerEntity.turnSpeed = 2.5f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearCart = true;
            player = other.gameObject;
            detection = player.GetComponentInChildren<DetectionScript>();
            nearestCaddie = detection.ClosestCaddie();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearCart = false;
            player = null;
            detection = null;
            nearestCaddie = null;
        }
    }
}
