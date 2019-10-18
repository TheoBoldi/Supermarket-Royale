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

        if (_rewiredPlayer.GetButtonDown("GrabCaddie") && detection.IsObjectInFront())
        {
            entity.GrabCaddie();
        }
    }
}
