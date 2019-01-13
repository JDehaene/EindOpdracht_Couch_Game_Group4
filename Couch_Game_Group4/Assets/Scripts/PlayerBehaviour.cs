using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerBehaviour : MonoBehaviour
{
    //External variables 
    private CharacterController _characterController;
    [SerializeField]
    private float _controllerID;
    //Input variable
    private float _horizontalInput;
    private float _verticalInput;

    //Player variables
    [SerializeField]
    private int _playerSpeed;
    private Vector3 _movement;
    private Vector3 _velocity;


    private float _jumpHeight = 20;
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
    public int _playerHealth = 3;

    //Bomb variables
    [SerializeField]
    private GameObject BombModel;
    private bool _throw;
    private bool _thrown;
    private BombBehaviour _bomb;
    private bool _restart;

    public Transform ModelAnchor;
    public int _bombCount;

    public Transform BossHead;
    private GameObject Bomb;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();       
    }

    void Update()
    {
        layerMask = 1 << 11;
        HandleInput();
        KillPlayer();
        ThrowBomb();
        Restart();
        BombChase();
    }
    private void FixedUpdate()
    {
        ApplyGravity();
        if (!_dash)
            Movement();

        Jump();
        Dash();
        if (!_dash)
            LimitMaximumRunningSpeed();

        _characterController.Move(_velocity);
    }

    private void HandleInput()
    {
        _horizontalInput = Input.GetAxis("HorizontalP"+ _controllerID);
        if (Input.GetButtonDown("JumpP" + _controllerID))
            _jump = true;
        if (Input.GetButtonDown("DashP" + _controllerID))
            _dash = true;
        if (Input.GetButtonDown("ThrowP" + _controllerID))
            _throw = true;
        if (Input.GetButtonDown("RestartP" + _controllerID))
            _restart = true;
    }
    //Move Methods
    private void Movement()
    {
        _velocity += Vector3.right * _playerSpeed * Time.deltaTime;
    }
    private void Jump()
    {
        if (_jump && _characterController.isGrounded)
        {
            Debug.Log("Jump works");
            _velocity.y = 0; //Reset so jump doesnt get dumped

            _velocity.y += _jumpHeight * Time.deltaTime; //Addjump
            _jump = false;
        }
    }
    private void Dash()
    {
        if (_dash && _dashAvailable == true)
        {
            Debug.Log("Dash works");
            _velocity.x += _dashSpeed * Time.deltaTime;
            _dashTimer += Time.deltaTime;
        }
        if (_dashTimer >= 0.1f) //Stop the dash
        {
            _dashTimer = 0;
            _dash = false;
            _dashAvailable = false; //Start cooldown
        }
        if (!_dashAvailable) //Keep track of cooldown
        {
            _dashCooldown += Time.deltaTime;
        }
        if (_dashCooldown >= 2) //Restrict dashing until cooldown off
        {
            _dashAvailable = true;
            _dashCooldown = 0;
        }
    }
    private void ApplyGravity()
    {
        if (!_characterController.isGrounded)
            _velocity -= new Vector3(0, 0.02f, 0);
    }
    private void LimitMaximumRunningSpeed()
    {
        Vector3 yVelocity = Vector3.Scale(_velocity, new Vector3(0, 1, 0));

        Vector3 xzVelocity = Vector3.Scale(_velocity, new Vector3(1, 0, 0));
        Vector3 clampedXzVelocity = Vector3.ClampMagnitude(xzVelocity, _maxRunningSpeed + _horizontalInput/10); //Make it go faster/slower

        _velocity = yVelocity + clampedXzVelocity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fist") || other.CompareTag("Spikes"))
        {
            HurtPlayer();
        }
        if(other.CompareTag("Bomb"))
        {
            _bombCount++;
        }
    }
    public void HurtPlayer()
    {
        _playerHealth--;
        Debug.Log("Ow");
    }
    private void KillPlayer()
    {
        if (_playerHealth <= 0)
            Destroy(this.gameObject);
    }
    private void ThrowBomb()
    {
        if(_throw && _bombCount >= 0)
        {
            Debug.Log(_bombCount);
            _bombCount--;
            Bomb = Instantiate(BombModel, ModelAnchor, false);
            _throw = false;
            _thrown = true;
        }
    }
    private void Restart()
    {
        if(_restart)
           SceneManager.LoadScene("Couch_game");
    }

    private void BombChase()
    {
        if (_thrown)
        {
            Bomb.transform.position = Vector3.MoveTowards(this.transform.position, BossHead.position, 3 * Time.deltaTime);
        }
    }

}

