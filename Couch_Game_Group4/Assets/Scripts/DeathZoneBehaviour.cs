using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneBehaviour : MonoBehaviour
{

    void Update()
    {



    }

    private void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.layer == LayerMask.NameToLayer("Player"))
        {

            Destroy(t);

        }
        
    }
}
