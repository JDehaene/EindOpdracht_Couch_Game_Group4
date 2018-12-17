using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour {

    private GameObject[] _levelPieces;
    private float _counter;
    [SerializeField]
    private Transform _bossLocation;
    private Transform _startLocation;
    
    void Update ()
    {
        SpawnRandomPiece();
	}
    void SpawnRandomPiece()
    {
        _counter+=Time.deltaTime;
        if(_counter >= 5)
        {
            int randomPiece = (int)(Random.Range(0, 3));
            Instantiate(_levelPieces[randomPiece], _startLocation);
            _counter = 0;
        }
            
    }
}
