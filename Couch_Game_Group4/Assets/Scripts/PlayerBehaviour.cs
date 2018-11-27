using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    //External variables 

    private Rigidbody _rb;
    //Input variable
    private float _horizontalInput;

    //Player variables
    [SerializeField]
    private int _playerSpeed;
    [SerializeField]
    private float _jumpHeight,_dashDistance;
    private bool _jump = false;
    private bool _dash = false;
    private bool _isGrounded;

    [SerializeField]
    private Transform _constraint;


    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleInput();
        IsGrounded();
        Movement();
        Jump();
        Dash();       
    }

    void HandleInput()
    {
        _horizontalInput = Input.GetAxis("HorizontalP2");
    }
    //Move Methods
    void Movement()
    {
        this.transform.position += Vector3.right * _playerSpeed*Time.deltaTime;
    }
    void Jump()
    {
        if (Input.GetButtonDown("JumpP2") && _isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
        }
        if(!_isGrounded)
        {
            this.transform.position -= Vector3.down*Time.deltaTime;
        }

    }
    void Dash()
    {
        if (Input.GetButtonDown("DashP2"))
        {
            _rb.AddForce(Vector3.right * _dashDistance, ForceMode.Impulse);
        }
    }

    void IsGrounded()
    {
        if (transform.position.y <= _constraint.position.y*1.5f)
        {
            _isGrounded = true;
        }
        else
            _isGrounded = false;
    }
}
