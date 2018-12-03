using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour2 : MonoBehaviour
{
    //External variables 
    private Rigidbody _rb;
    //Input variable
    private float _horizontalInput;
    private float _verticalInput;

    //Player variables
    [SerializeField]
    private int _playerSpeed;
    private Vector3 _velocity = Vector3.zero;
    [SerializeField]
    private float _jumpHeight, _dashSpeed;
    private float _fallSpeed = 20;
    private float _dashTime;
    private bool _jump = false;
    private bool _dash = false;
    private bool _isGrounded;
    [SerializeField]
    private Transform _constraint;
    private float _counter;
    private int layerMask;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        layerMask = 1 << 11;
        HandleInput();
        IsGrounded();
        Movement();
        Jump();
        Dash();
    }

    void HandleInput()
    {
        _horizontalInput = Input.GetAxis("HorizontalP4");
        _verticalInput = Input.GetAxis("VerticalP4");
    }
    //Move Methods
    void Movement()
    {
        this.transform.position += Vector3.right * _playerSpeed*Time.deltaTime;
    }
    void Jump()
    {

        if (Input.GetButtonDown("JumpP4") && _isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpHeight, ForceMode.Impulse);
        }
        else
        {
            _rb.useGravity = true;
        }
    }
    void Dash()
    {
        if (Input.GetButtonDown("DashP4") && _dash == false)
        {
            _rb.velocity = Vector3.zero;
            _rb.AddForce(Vector3.right * _dashSpeed *_horizontalInput, ForceMode.Impulse);
            _dash = true;
        }
        if(_dash)
        {
            _counter += Time.deltaTime;
        }
        if(_counter > _dashTime)
        {
            _rb.velocity = Vector3.zero;
            _counter = 0;
            _dash = false;            
        }
        if (_horizontalInput < 0)
        {
            _dashTime = 0.1f;
        }
        else
        {        
            _dashTime = 0.2f;
        }
    }

    void IsGrounded()
    {       
        Vector3 down = transform.TransformDirection(Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, down, out hit, 4f, layerMask))
        {
            _isGrounded = true;
        }
        else
            _isGrounded = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fist")
        Destroy(this.gameObject);
    }
}


