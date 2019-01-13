using UnityEngine;

public class FistBehaviour : MonoBehaviour {

    private float  _rightVertInput, _rightHorizInput;
    private float _leftHorizInput,_leftVertInput;
    [SerializeField]
    private Transform _leftFist, _rightFist;
    public Transform _fistConstraint;
    private PlayerBehaviour player;

    //Left fist variables
    private bool _canSlamLeftFist;
    private bool _canMoveLeftFist;
    [SerializeField]
    private GameObject _returnLeftFist; //Return positions after slamming
    private float _leftFistCooldown;

    //Right fist variables
    private bool _canSlamRightFist;
    private bool _canMoveRightFist;
    [SerializeField]
    private GameObject _returnRightFist;
    private float _rightFistCooldown;

    //Move variables
    public  float _moveSpeed;
    private float _speedIncreaseLeft = 2f;
    private float _speedIncreaseRight = 2f;

    //Camera variable
    private bool _shake;

    [SerializeField]
    private float _shakeDuration,_shakeMagnitude;
    public ShakeBehaviour CameraShake;


    private bool _slammingLeft,_slammingRight;
    private int _bossHealth = 5;

    void Update ()
    {
        HandleInput();
        MoveBoss();
        LeftFist();
        RightFist();

        //ShakeCamera independent of fist
        if (_shake)
            ShakeCamera();
    }
    void LeftFist()
    {
        CheckLeftFistLocation();
        ReturnLeftFist();
        if (_canSlamLeftFist)
        {
            leftFistMovement();           
        }

    }
    void RightFist()
    {
        CheckRightFistLocation();
        ReturnRightFist();
        if (_canSlamRightFist)
        {
            RightFistMovement();
        }

    }
    void HandleInput()
    {
        _leftHorizInput = Input.GetAxis("LeftHorizontalP1");           
        _leftVertInput = Input.GetAxis("LeftVerticalP1");
      
        _rightHorizInput = Input.GetAxis("RightHorizontalP1");
        _rightVertInput = Input.GetAxis("RightVerticalP1");

        if (_leftVertInput < 0)
            _slammingLeft = true;
        if (_rightVertInput < 0)
            _slammingRight = true;
    }

    //Left Fist Methods
    void leftFistMovement()
    {
        float _speedIncrement = 10 * Time.deltaTime; 
        if (_slammingLeft) //Prevent from going up   
        {
            _speedIncreaseLeft -= _speedIncrement;  //Interesting movementincrease
            _leftFist.position += new Vector3(0, _leftVertInput + _speedIncreaseLeft, 0); //Vertical movement       
        }
        else
        {
            _speedIncreaseLeft = 2f;
            _leftFist.position += new Vector3(_leftHorizInput/2, 0, 0); //Horizontal movement
        }
    }  
    void CheckLeftFistLocation()
    {
        if (_leftFist.transform.position.y < _fistConstraint.transform.position.y)
        {
            _canSlamLeftFist = false;
            _canMoveLeftFist = false;
            _slammingLeft = false;
            _shake = true;
        }
            
    }
    void ReturnLeftFist()
    {
        if(_canSlamLeftFist == false)
        {
            _leftFistCooldown += Time.deltaTime;    
            if(_leftFistCooldown >= 1.5f)
            {
                _leftFist.transform.position = _returnLeftFist.transform.position;
                _leftFistCooldown = 0;
                _canSlamLeftFist = true;
                _canMoveLeftFist = true;
            }            
        }      
    }

    //Right Fist Methods

    void RightFistMovement()
    {
        float _speedIncrement = 10 * Time.deltaTime;
        if (_slammingRight)
        {
            _speedIncreaseRight -= _speedIncrement;  //Interesting movementincrease
            _rightFist.position += new Vector3(0, _rightVertInput + _speedIncreaseRight, 0);
        }
        else
        {
            _speedIncreaseRight = 2f;
            _rightFist.position += new Vector3(_rightHorizInput/2, 0, 0);
        }
    }
    void CheckRightFistLocation()
    {
        if (_rightFist.transform.position.y < _fistConstraint.transform.position.y)
        {
            _canSlamRightFist = false;
            _canMoveRightFist = false;
            _slammingRight = false;
            _shake = true;
        }

    }
    void ReturnRightFist()
    {
        if (_canSlamRightFist == false)
        {
            _rightFistCooldown += Time.deltaTime;
            if (_rightFistCooldown >= 1.5f)
            {
                _rightFist.transform.position = _returnRightFist.transform.position;
                _rightFistCooldown = 0;
                _canSlamRightFist = true;
                _canMoveRightFist = true;
            }
        }
    }

    //Move method
    void MoveBoss()
    {
        transform.position += new Vector3(_moveSpeed * Time.deltaTime, 0, 0);
    }
   
    //Shake method
    void ShakeCamera()
    {       
        StartCoroutine(CameraShake.Shake(_shakeDuration, _shakeMagnitude));
        _shake = false;       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bomb"))
        {
            _bossHealth--;
            Destroy(other.gameObject);
        }
    }

}
