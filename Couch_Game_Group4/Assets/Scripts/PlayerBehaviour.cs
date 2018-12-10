using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    //External variables 
    private CharacterController _characterController;
    //Input variable
    private float _horizontalInput;
    private float _verticalInput;

    //Player variables
    [SerializeField]
    private int _playerSpeed;
    private Vector3 _movement;
    private Vector3 _velocity;

    
    private float _jumpHeight = 30;
    private float _dashSpeed = 15;

    private float _dashTimer;
    private bool _jump = false;
    private bool _dash = false;
    private bool _isGrounded;
    private float _counter;
    private int layerMask;
    private float _maxRunningSpeed = 0.2f;
    private float _dashCooldown = 3;
    private bool _dashAvailable;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        layerMask = 1 << 11;
        HandleInput();      
       
        
    }
    private void FixedUpdate()
    {
        ApplyGravity();
        if(!_dash)
        Movement();
        
        Jump();
        Dash();
        if(!_dash)
            LimitMaximumRunningSpeed();

        _characterController.Move(_velocity);
    }

    void HandleInput()
    {
        _horizontalInput = Input.GetAxis("HorizontalP2");       
        if (Input.GetButtonDown("JumpP2"))
            _jump = true;
        if (Input.GetButtonDown("DashP2"))
            _dash = true;
    }
    //Move Methods
    void Movement()
    {
        _velocity += Vector3.right * _playerSpeed * Time.deltaTime;
    }
    void Jump()
    {
        if (_jump && _characterController.isGrounded)
        {
            _velocity.y = 0; //Reset so jump doesnt get dumped
            
            _velocity.y += _jumpHeight * Time.deltaTime; //Addjump
            _jump = false;
        }
    }
    void Dash()
    {
        Debug.Log(_dashAvailable);
        if (_dash && _dashAvailable == true)
        {
            _velocity.x += _dashSpeed * Time.deltaTime;
            _dashTimer+=Time.deltaTime;
        }
        if(_dashTimer >= 0.1f) //Stop the dash
        {
            _dashTimer = 0;            
            _dash = false;
            _dashAvailable = false; //Start cooldown
        }
        if (!_dashAvailable) //Keep track of cooldown
        {
            _dashCooldown += Time.deltaTime;
            Debug.Log(_dashCooldown);
        }
        if(_dashCooldown >= 3) //Restrict dashing until cooldown off
        {
            _dashAvailable = true;
            _dashCooldown = 0;
        }
    }
    void ApplyGravity()
    {
        if(!_characterController.isGrounded)
        _velocity -= new Vector3(0,0.05f,0);
    }
    private void LimitMaximumRunningSpeed()
    {
        Vector3 yVelocity = Vector3.Scale(_velocity, new Vector3(0, 1, 0));

        Vector3 xzVelocity = Vector3.Scale(_velocity, new Vector3(1, 0, 1));
        Vector3 clampedXzVelocity = Vector3.ClampMagnitude(xzVelocity, _maxRunningSpeed + _horizontalInput/20); //Make it go faster/slower

        _velocity = yVelocity + clampedXzVelocity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fist")
        Destroy(this.gameObject);
    }   
}


