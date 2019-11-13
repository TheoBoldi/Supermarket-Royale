using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEntity : MonoBehaviour
{
    //Script par Théo

    //Vitesse
    private float acceleration;
    private float moveSpeedMax;

    //Inertie
    private float friction;
    private float turnFriction;

    //Rotation
    private float turnSpeed;

    [Header("Vitesse")]
    [Header("Stats Player")]
    public float accelerationPlayer = 20f;
    public float moveSpeedMaxPlayer = 10f;

    [Header("Inertie")]
    public float frictionPlayer = 0f;
    public float turnFrictionPlayer = 20f;

    [Header("Rotation")]
    public float turnSpeedPlayer = 15f;

    [Header("Vitesse")]
    [Header("Stats Caddie")]
    public float accelerationCaddie = 20f;
    public float moveSpeedMaxCaddie = 10f;

    [Header("Inertie")]
    public float frictionCaddie = 0f;
    public float turnFrictionCaddie = 20f;

    [Header("Rotation")]
    public float turnSpeedCaddie = 15f;

    [Header("Game Objects")]
    public GameObject modelObj;
    public Transform cartPos;
    public Transform nearestCaddie;

    public bool stopMove;
    public bool haveCaddie;

    private Vector3 _moveDir;
    private Vector3 _orientDir = Vector3.right;
    private Vector3 _velocity = Vector3.zero;

    private Rigidbody rb;
    private DetectionScript detection;

    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        acceleration = accelerationPlayer;
        moveSpeedMax = moveSpeedMaxPlayer;
        friction = frictionPlayer;
        turnFriction = turnFrictionPlayer;
        turnSpeed = turnSpeedPlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
        cartPos = modelObj.GetComponentInChildren<Transform>().GetChild(0);
        detection = GetComponentInChildren<DetectionScript>();
    }

    private void FixedUpdate()
    {
        if (!stopMove)
        {
            _UpdateMove();
            _UpdateModelOrient();
        }

        _UpdateAnim();

        Vector3 newPosition = transform.position;
        newPosition.x += _velocity.x * Time.fixedDeltaTime;
        newPosition.z += _velocity.z * Time.fixedDeltaTime;
        rb.transform.position = newPosition;
        rb.velocity = Vector3.zero;
    }

    public void Update()
    {
        nearestCaddie = detection.ClosestCaddie();
    }

    public void GrabCaddie()
    {
        if(nearestCaddie != null && !nearestCaddie.GetComponentInChildren<ShoppingCartController>().cartIsUsed)
        {
            if (nearestCaddie.GetComponentInChildren<ShoppingCartController>().isNearCart)
            {
                nearestCaddie.GetComponentInChildren<ShoppingCartController>().cartIsUsed = true;
                CartControls();
            }
        }
    }

    public void DropCaddie()
    {
        if (nearestCaddie != null)
        {
            nearestCaddie.GetComponentInChildren<ShoppingCartController>().cartIsUsed = false;
            PlayerControls();
        }
    }

    #region Functions Move

    public void PlayerControls()
    {
        acceleration = accelerationPlayer;
        moveSpeedMax = moveSpeedMaxPlayer;
        friction = frictionPlayer;
        turnFriction = turnFrictionPlayer;
        turnSpeed = turnSpeedPlayer;
        nearestCaddie.transform.parent = null;
        haveCaddie = false;
    }

    public void CartControls()
    {
        if (nearestCaddie != null)
        {
            nearestCaddie.transform.position = cartPos.position;
            nearestCaddie.transform.rotation = cartPos.rotation;
            nearestCaddie.transform.parent = cartPos;
            acceleration = accelerationCaddie;
            moveSpeedMax = moveSpeedMaxCaddie;
            friction = frictionCaddie;
            turnFriction = turnFrictionCaddie;
            turnSpeed = turnSpeedCaddie;
            haveCaddie = true;
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

    public void StopMove()
    {
        stopMove = true;
        _velocity = Vector3.zero;
    }

    public void RestartMove()
    {
        stopMove = false;
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

    private void _UpdateAnim()
    {
        if(_moveDir != Vector3.zero)
        {
            if (haveCaddie)
            {
                animator.SetBool("CaddieWalk", true);
                animator.SetBool("CaddieIdle", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Walk", false);
            }
            else if(!haveCaddie)
            {
                animator.SetBool("Walk", true);
                animator.SetBool("Idle", false);
                animator.SetBool("CaddieWalk", false);
                animator.SetBool("CaddieIdle", false);
                //SoundManager.instance.StopSoundCaddie();
            }
        }
        else if(_moveDir == Vector3.zero)
        {
            if (haveCaddie)
            {
                animator.SetBool("CaddieIdle", true);
                animator.SetBool("Walk", false);
                animator.SetBool("Idle", false);
                animator.SetBool("CaddieWalk", false);
                //SoundManager.instance.StopSoundCaddie();
            }
            else if(!haveCaddie)
            {
                animator.SetBool("Idle", true);
                animator.SetBool("Walk", false);
                animator.SetBool("CaddieWalk", false);
                animator.SetBool("CaddieIdle", false);
                //SoundManager.instance.StopSoundCaddie();
            }
        }

        if(_velocity != Vector3.zero)
        {
            if (haveCaddie && !SoundManager.instance.soundCaddie.isPlaying)
            {
                SoundManager.instance.SoundCaddie();
            }
        }
        else if(_velocity == Vector3.zero)
        {
            if (SoundManager.instance.soundCaddie.isPlaying)
            {
                SoundManager.instance.soundCaddie.Stop();
            }
        }
    }
    #endregion
}
