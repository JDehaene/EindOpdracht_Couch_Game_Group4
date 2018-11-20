using UnityEngine;

public class FistBehaviour : MonoBehaviour {

    private float  _rightVertInput, _rightHorizInput;
    private float _leftHorizInput,_leftVertInput;
    [SerializeField]
    private Transform _leftFist,_rightFist,_fistConstraint;
    private bool _smashingLeft;

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
    [SerializeField]
    private float _moveSpeed;


    void Update ()
    {
        Debug.Log(_smashingLeft);
        HandleInput();
        MoveBoss();
        LeftFist();
        RightFist();
        

    }
    void LeftFist()
    {
        CheckLeftFistLocation();
        ReturnLeftFist();
        if (_canSlamLeftFist)
        {
            leftFistMovement();
            FasterGravity();
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
        _leftHorizInput = Input.GetAxis("Horizontal");           
        _leftVertInput = Input.GetAxis("Vertical");
      
        _rightHorizInput = Input.GetAxis("MouseX");
        _rightVertInput = Input.GetAxis("MouseY");
    }

    //Left Fist Methods
    void leftFistMovement()
    {
        if (_leftVertInput < 0) //Prevent from going up        
            _leftFist.position += new Vector3(_leftHorizInput / 10, _leftVertInput, 0); //Vertical movement       
        else
            _leftFist.position += new Vector3(_leftHorizInput, 0, 0); //Horizontal movement

        _smashingLeft = false;
    }  
    void CheckLeftFistLocation()
    {
        if (_leftFist.transform.position.y < _fistConstraint.transform.position.y)
        {
            _canSlamLeftFist = false;
            _canMoveLeftFist = false;
        }
            
    }
    void ReturnLeftFist()
    {
        if(_canSlamLeftFist == false)
        {
            _leftFistCooldown += Time.deltaTime;    
            if(_leftFistCooldown >= 1)
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
        if (_rightVertInput < 0)
            _rightFist.position += new Vector3(_rightHorizInput/10, _rightVertInput, 0);
        else
            _rightFist.position += new Vector3(_rightHorizInput, 0, 0);
    }
    void CheckRightFistLocation()
    {
        if (_rightFist.transform.position.y < _fistConstraint.transform.position.y)
        {
            _canSlamRightFist = false;
            _canMoveRightFist = false;
        }

    }
    void ReturnRightFist()
    {
        if (_canSlamRightFist == false)
        {
            _rightFistCooldown += Time.deltaTime;
            if (_rightFistCooldown >= 1)
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
        this.transform.position += new Vector3(_moveSpeed * Time.deltaTime, 0, 0);
    }
    //Interesting movement

    void FasterGravity()
    {
        //to be continued
    }
}
