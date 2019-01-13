using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehaviour : MonoBehaviour
{
    private PlayerBehaviour _player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _player.HurtPlayer();
        }
    }
}
