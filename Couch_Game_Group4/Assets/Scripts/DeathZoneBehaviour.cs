using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Dood");
            Destroy(t.gameObject);

        }
        
    }
}
