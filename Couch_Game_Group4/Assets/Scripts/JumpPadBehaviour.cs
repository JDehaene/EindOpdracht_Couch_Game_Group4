using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadBehaviour : MonoBehaviour {

    [SerializeField]
    private float _jumpPadPower;

    [SerializeField]
    private bool _isFacingUp;

    [SerializeField]
    private bool _isFacingLeft;

    [SerializeField]
    private bool _isFacingRight;


    private void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("JumpPad used!");

            if (_isFacingUp)
            {
                t.transform.position += new Vector3(0, _jumpPadPower, 0);
            }

            if (_isFacingRight)
            {
                t.transform.position += new Vector3(_jumpPadPower, 0, 0);
            }

            if (_isFacingLeft)
            {
                t.transform.position += new Vector3(-_jumpPadPower, 0, 0);
            }


        }
    }



}
