using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    //Script par Théo

    public static float acceleration = 20f;
    public static float moveSpeedMax = 10f;
    public static float friction = 30f;
    public static float turnFriction = 20f;
    public static float turnSpeed = 15f;

    private Vector3 _moveDir;
    private Vector3 _orientDir = Vector3.right;
    private Vector3 _velocity = Vector3.zero;

    public GameObject modelObj;
    public static Transform cartPos;

    // Start is called before the first frame update
    void Start()
    {
        cartPos = modelObj.GetComponentInChildren<Transform>().GetChild(2);
    }

    private void FixedUpdate()
    {
        _UpdateMove();
        _UpdateModelOrient();

        Vector3 newPosition = transform.position;
        newPosition.x += _velocity.x * Time.fixedDeltaTime;
        newPosition.z += _velocity.z * Time.fixedDeltaTime;
        transform.position = newPosition;
    }

    public void GrabCaddie()
    {
        if (ShoppingCartController.isNearCart)
        {
            ShoppingCartController.cartIsUsed = !ShoppingCartController.cartIsUsed;
        }
    }

    #region Functions Move

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
