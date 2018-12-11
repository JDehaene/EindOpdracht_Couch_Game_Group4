using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{   
    public int playerID = 1;
    public int controllerID = 1;
    public Text txtInfo;
    public bool Start = false;

    public void Active(int ctrl)
    {
        this.enabled = true;
        controllerID = ctrl;
        txtInfo.text = "Press 'Y' to back out";

    }

    public void DeActive()
    {
        this.enabled = false;
        txtInfo.text = "Press 'A' to join";
    }
    public void StartGame()
    {
        Start = true;
    }
}
