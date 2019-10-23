﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    //Script par Théo

    [Header("Vitesse")]
    public float acceleration = 20f;
    public float moveSpeedMax = 10f;

    [Header("Intertie")]
    public float friction = 30f;
    public float turnFriction = 20f;

    [Header("Rotation")]
    public float turnSpeed = 15f;

    [Header("Game Objects")]
    public GameObject modelObj;
    public Transform cartPos;
    public Transform nearestCaddie;

    private Vector3 _moveDir;
    private Vector3 _orientDir = Vector3.right;
    private Vector3 _velocity = Vector3.zero;

    private Rigidbody rb;
    private DetectionScript detection;



    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        cartPos = modelObj.GetComponentInChildren<Transform>().GetChild(2);
        detection = GetComponentInChildren<DetectionScript>();
    }

    private void FixedUpdate()
    {
        _UpdateMove();
        _UpdateModelOrient();

        Vector3 newPosition = transform.position;
        newPosition.x += _velocity.x * Time.fixedDeltaTime;
        newPosition.z += _velocity.z * Time.fixedDeltaTime;
        rb.transform.position = newPosition;
        rb.velocity = Vector3.zero;
    }

    public void Update()
    {
        if (ShoppingCartController.cartIsUsed)
        {
            CartControls();
        }
        else
        {
            PlayerControls();
        }

        nearestCaddie = detection.ClosestCaddie();
    }

    public void GrabCaddie()
    {
        if (ShoppingCartController.isNearCart)
        {
            ShoppingCartController.cartIsUsed = !ShoppingCartController.cartIsUsed;
        }
    }

    #region Functions Move

    public void PlayerControls()
    {
        acceleration = 100f;
        moveSpeedMax = 8f;
        friction = 100f;
        turnFriction = 0f;
        turnSpeed = 15f;
    }

    public void CartControls()
    {
        if (nearestCaddie != null)
        {
            nearestCaddie.transform.position = cartPos.position;
            nearestCaddie.transform.rotation = cartPos.rotation;
            acceleration = 10f;
            moveSpeedMax = 6.4f;
            friction = 10f;
            turnFriction = 20f;
            turnSpeed = 2.5f;
        }
    }

    private void _UpdateModelOrient()
    {
        float startAngle = modelObj.transform.eulerAngles.y;
        float endAngle = startAngle + Vector3.SignedAngle(modelObj.transform.forward, _orientDir, Vector3.up);
        float angle = Mathf.Lerp(startAngle, endAngle, turnSpeed * Time.deltaTime);

        Vector3 eulerAngles = modelObj.transform.eulerAngles;
        eulerAngles.y = angle;
        modelObj.transform.eulerAngles = eulerAngles;
    }

    public void Move(Vector3 dir)
    {
        _moveDir = dir;
    }

    private void _UpdateMove()
    {
        if (_moveDir != Vector3.zero)
        {
            float turnAngle = Vector3.SignedAngle(_velocity, Vector3.zero, _moveDir);
            turnAngle = Mathf.Abs(turnAngle);
            float frictionRatio = turnAngle / 360f;
            float turnFrictionWithRatio = turnFriction * frictionRatio;

            _velocity += _moveDir * acceleration * Time.fixedDeltaTime;
            if (_velocity.sqrMagnitude > moveSpeedMax * moveSpeedMax)
            {
                _velocity = _velocity.normalized * moveSpeedMax;
            }

            Vector3 frictionDir = _velocity.normalized;
            _velocity -= frictionDir * turnFrictionWithRatio * Time.fixedDeltaTime;

            _orientDir = _velocity.normalized;
        }
        else if (_velocity != Vector3.zero)
        {
            Vector3 frictionDir = _velocity.normalized;
            float frictionToApply = friction * Time.fixedDeltaTime;
            if (_velocity.sqrMagnitude <= frictionToApply * frictionToApply)
            {
                _velocity = Vector3.zero;
            }
            else
            {
                _velocity -= frictionDir * frictionToApply;
            }
        }
    }
    #endregion
}
