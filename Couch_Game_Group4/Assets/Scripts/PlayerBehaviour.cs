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
    private Vector3 _velocity;
    [SerializeField]
    private float _jumpHeight, _dashSpeed;
    private float _fallSpeed = 20;
    private float _dashTime;
    private bool _jump = false;
    private bool _dash = false;
    private bool _isGrounded;
    private float _counter;
    private int layerMask;
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        layerMask = 1 << 11;
        HandleInput();      
        Movement();
        
    }
    private void FixedUpdate()
    {
        ApplyGravity();
        Jump();       
        Dash();


        _characterController.Move(_velocity);
    }

    void HandleInput()
    {
        _horizontalInput = Input.GetAxis("HorizontalP2");
        _verticalInput = Input.GetAxis("VerticalP2");

        if (Input.GetButtonDown("JumpP2"))
            _jump = true;
    }
    //Move Methods
    void Movement()
    {
        
        _velocity = new Vector3(_horizontalInput,0,0) * _playerSpeed*Time.deltaTime;
    }
    void Jump()     
    {
        if (_jump && _characterController.isGrounded)
        {
            _velocity.y +=  Mathf.Sqrt(2*Physics.gravity.magnitude * _jumpHeight);
            _jump = false;
        }
    }
    void Dash()
    {
   
    }
    void ApplyGravity()
    {
        _velocity += Physics.gravity*Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Fist")
        Destroy(this.gameObject);
    }
    //Debug.Log(_isGrounded);
    //if (Input.GetButtonDown("JumpP2") && _isGrounded)
    //{
    //    _rb.AddForce(Vector3.up* _jumpHeight, ForceMode.Impulse);
    //}
    //if(!_isGrounded)
    //{
    //    _rb.useGravity = true;
    //    if (_verticalInput > 0)
    //    {
    //        _rb.velocity = Vector3.zero;
    //        transform.position -= new Vector3(0, _fallSpeed* _verticalInput * Time.deltaTime, 0);
    //    }
    //}

    //    if (Input.GetButtonDown("DashP2") && _dash == false)
    //    {
    //        _rb.velocity = Vector3.zero;
    //        _rb.AddForce(Vector3.right * _dashSpeed *_horizontalInput, ForceMode.Impulse);
    //        _dash = true;
    //    }
    //    if(_dash)
    //    {
    //        _counter += Time.deltaTime;
    //    }
    //    if(_counter > _dashTime)
    //    {
    //        _rb.velocity = Vector3.zero;
    //        _counter = 0;
    //        _dash = false;            
    //    }
    //    if (_horizontalInput < 0)
    //    {
    //        _dashTime = 0.1f;
    //    }
    //    else
    //    {        
    //        _dashTime = 0.2f;
    //    }

    //Vector3 down = transform.TransformDirection(Vector3.down);
    //RaycastHit hit;

    //if (Physics.Raycast(transform.position, down, out hit, 4f, layerMask))
    //{
    //    _isGrounded = true;
    //}
    //else
    //    _isGrounded = false;
}


