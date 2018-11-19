using UnityEngine;

public class FistBehaviour : MonoBehaviour {

    private float _leftVertInput, _leftHorizInput, _rightVertInput, _rightHorizInput;
    [SerializeField]
    private GameObject _leftFist,_rightFist,_fistConstraint;


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


    void Update ()
    {
        HandleInput();
        Debug.Log(_rightHorizInput);

        LeftFist();
        RightFist();


    }
    void LeftFist()
    {
        CheckLeftFistLocation();
        ReturnLeftFist();
        if (_canSlamLeftFist)
        {
            SlamLeftFist();
        }
        if (_canMoveLeftFist)
        {
            MoveLeftFist();
        }
    }
    void RightFist()
    {
        CheckRightFistLocation();
        ReturnRightFist();
        if (_canSlamRightFist)
        {
            SlamRightFist();
        }
        if (_canMoveRightFist)
        {           
            MoveRightFist();
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
    void SlamLeftFist()
    {
        _leftFist.transform.position +=  new Vector3(0,_leftVertInput,0);        
    }
    void MoveLeftFist()
    {
        _leftFist.transform.position +=  new Vector3(_leftHorizInput, 0, 0);
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
    
    void SlamRightFist()
    {
        _rightFist.transform.position += new Vector3(0, _rightVertInput, 0);
    }
    void MoveRightFist()
    {
        _rightFist.transform.position += new Vector3(_rightHorizInput, 0, 0);
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
}
