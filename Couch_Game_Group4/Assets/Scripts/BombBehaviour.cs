using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour {

    private int Fist1Health = 2;
    private int Fist2Health = 2;
    private int _fistChoice;

    [SerializeField]
    private GameObject _leftFist, _rightFist;
    [SerializeField]
    private Material _leftFistHealth,_rightFistHealth;
    private Color _standard = new Color(132, 81, 12);
    private bool _bombExplode;

    private void Start()
    {
        if (Fist1Health == 2)
            _leftFistHealth.color = Color.black;
        if (Fist2Health == 2)
            _rightFistHealth.color = Color.black;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _bombExplode = true;
            DamageFist();
            AssignDamageToFist();
            Destroy(this.gameObject);
        }
    }

    void DamageFist()
    {
        if(_bombExplode)
        {
           _fistChoice = Random.Range(1, 3);
        }
        _bombExplode = false;
        
        if (_fistChoice == 1)
            Fist1Health--;
        else
            Fist2Health--;

    }

    void AssignDamageToFist()
    {
        

        if (Fist1Health == 1)
        {
            _leftFistHealth.color = Color.yellow;
            Debug.Log("colored");
        }

        if (Fist1Health == 0)
            Destroy(_leftFist);

        if (Fist2Health == 1)
        {
            _rightFistHealth.color = Color.yellow;
            Debug.Log("colored");
        }

        if (Fist2Health == 0)
            Destroy(_rightFist);
    }
}
