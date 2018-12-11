using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour {

    private float _fistHealth;

    private bool _bombTriggered;

    void Start()
    {

    }
    private void Update()
    {
        BombDamage();
    }

    void BombDamage()
    {
        if(_bombTriggered)
        {
            _fistHealth--;
            Destroy(this.gameObject);
            _bombTriggered = false;
            
        }
    }
    void StartPhase2()
    {
        if(_fistHealth <= 0)
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            _bombTriggered = true;
    }


}
