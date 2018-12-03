using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

    [SerializeField]
    private float _JumpPadPower;

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.layer == LayerMask.NameToLayer("JumpPad"))
        {
            Debug.Log("JumpPad used!");
            this.transform.position += new Vector3(0, _JumpPadPower, 0);
        }

        if (c.gameObject.layer == LayerMask.NameToLayer("Spikes"))
        {
            Debug.Log("Died");
            Destroy(this);
        }

    }
}
