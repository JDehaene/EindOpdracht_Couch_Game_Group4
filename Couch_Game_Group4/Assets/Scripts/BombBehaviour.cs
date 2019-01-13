using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour {

    private bool _bombTriggered;
    private PlayerBehaviour BombPickup;

    private void Update()
    {
        BombTrigger();
    }

    void BombTrigger()
    {
        if(_bombTriggered)
        {         
            Destroy(this.gameObject);            
            _bombTriggered = false;           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _bombTriggered = true;
        }
    }
}
