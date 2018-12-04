using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehaviour : MonoBehaviour
{

    private void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Fell into the spikes!");
            Destroy(t);

        }
    }

}
