using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private CharacterController _characterController;
    private float _horizontalInput;

    [SerializeField]
    private int _playerSpeed;

    private Vector3 _velocity;
    [SerializeField]
    private float _jumpHeight;
    private bool _jump;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleInput();
        
        
    }
    private void FixedUpdate()
    {
       
        Movement();
        Jump();
        Gravity();
        _characterController.Move(_velocity*Time.deltaTime);
      
    }

    void HandleInput()
    {
        _horizontalInput = Input.GetAxis("Player1Horizontal");
        if (Input.GetButtonDown("Player1Jump"))
        {
            _jump = true;
        }
    }

    void Movement()
    {
        _velocity = Vector3.right * _playerSpeed * Time.deltaTime;
    }

    void Jump()
    {
        if(_jump && _characterController.isGrounded)
        {
            _velocity += -Physics.gravity.normalized * Mathf.Sqrt(2 * Physics.gravity.magnitude * _jumpHeight);
            _jump = false;
        }
    }
    void Dash()
    {
        if(Input.GetButtonDown("Player1Dash"))
        {

        }
    }

    void Gravity()
    {
        Debug.Log("Active");
        _velocity += Physics.gravity;
    }
}
