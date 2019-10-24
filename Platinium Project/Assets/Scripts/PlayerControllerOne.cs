﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerControllerOne : MonoBehaviour
{
    //Script par Théo

    public PlayerEntity entity;
    private Player _rewiredPlayer;
    public DetectionScript detection;

    public float coef;
    public float radangle;
    public bool sign;

    // Start is called before the first frame update
    void Start()
    {
        _rewiredPlayer = ReInput.players.GetPlayer("Player1");
        detection = entity.GetComponentInChildren<DetectionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = _rewiredPlayer.GetAxis("MoveHorizontal");
        float dirZ = _rewiredPlayer.GetAxis("MoveVertical");

        Vector3 moveDir = new Vector3(dirX, 0, dirZ);
        moveDir.Normalize();

        entity.Move(moveDir);

        /*if (_rewiredPlayer.GetButtonDown("GrabCaddie") && detection.IsObjectInFront())
        {
            entity.GrabCaddie();
        }

        if ((_rewiredPlayer.GetAxis("RightTrigger") > 0))
        {
            Vector3 refvector = entity.GetComponentInChildren<Transform>().GetChild(0).transform.rotation.eulerAngles;
            coef = Mathf.Abs(Mathf.Sqrt((_rewiredPlayer.GetAxis("MoveHorizontal") * _rewiredPlayer.GetAxis("MoveHorizontal")) + (_rewiredPlayer.GetAxis("MoveVertical") * _rewiredPlayer.GetAxis("MoveVertical"))));
            radangle = refvector.y * Mathf.Deg2Rad;
            sign = (((Mathf.Cos(radangle) * _rewiredPlayer.GetAxis("MoveHorizontal")) + (Mathf.Cos(radangle) * _rewiredPlayer.GetAxis("MoveVertical"))) >= 0);
            if (sign == true)
            {
                entity.Move(new Vector3(coef, 0, 0));
            }
            else if (sign == false)
            {
                entity.Move(new Vector3(-coef, 0, 0));
            }

        }else
        if ((Mathf.Sqrt((_rewiredPlayer.GetAxis("MoveHorizontal") * _rewiredPlayer.GetAxis("MoveHorizontal")) + (_rewiredPlayer.GetAxis("MoveVertical") * _rewiredPlayer.GetAxis("MoveVertical"))) > 0.2f) || (Mathf.Sqrt((_rewiredPlayer.GetAxis("MoveHorizontal") * _rewiredPlayer.GetAxis("MoveHorizontal")) + (_rewiredPlayer.GetAxis("MoveVertical") * _rewiredPlayer.GetAxis("MoveVertical"))) < -0.2f))
        {
            //je bouge
            entity.Move(new Vector3(dirX, 0, dirZ));
        }
        //sinon
        else
        {
            //je me tourne
            entity.GetComponentInChildren<Transform>().GetChild(0).transform.rotation = Quaternion.Euler(entity.GetComponentInChildren<Transform>().GetChild(0).transform.rotation.x, (Mathf.Atan2(_rewiredPlayer.GetAxis("MoveHorizontal"), _rewiredPlayer.GetAxis("MoveVertical")) * Mathf.Rad2Deg) - 90f, entity.GetComponentInChildren<Transform>().GetChild(0).transform.rotation.z);
        }*/

    }
}
