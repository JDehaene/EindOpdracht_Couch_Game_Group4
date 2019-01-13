using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerBehaviour : MonoBehaviour {
    private float _countDown = 80;
    public Text TxtInfo;

	void Update ()
    {
        if (_countDown >= 0)
            _countDown -= 1*Time.deltaTime;

        TxtInfo.text = "Time until players escape Pygmi :" + (int)_countDown;
	}
}
