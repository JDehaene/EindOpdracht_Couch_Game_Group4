using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneBehaviour : MonoBehaviour
{
    public PlayerBehaviour _player;
    private void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            t.transform.position += new Vector3(5, 0, 0);
            _player.HurtPlayer();
        }     
    }
}
