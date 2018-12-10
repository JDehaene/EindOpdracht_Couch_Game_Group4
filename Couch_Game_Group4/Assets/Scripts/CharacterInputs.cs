﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CharacterControl : MonoBehaviour {

    public UIBehaviour[] Players;
    private List<int> activePlayers = new List<int>();

    public GameObject bannerTimer;
    private bool isCounting = false;
    public Text txtCounter;
    public float maxTime = 30;
    private float counter = 0;
	
	void Update ()
    {
        CheckCounter();
        CheckInput();
    }

    void CheckCounter()
    {
        if( isCounting)
        {
            if( activePlayers.Count < 2)
            {
                counter = 0;
                isCounting = false;
                bannerTimer.SetActive(false);
                return;
            }

            counter += Time.deltaTime;
            txtCounter.text = ""+ (int) (maxTime - counter);

            if( counter >= maxTime)
            {
                this.enabled = false;
                txtCounter.text = "Start";
                for (int i = 0; i < Players.Length; ++i)
                {
                    //Players[i].StartGame();
                }
            }
        }
        else if( activePlayers.Count > 1)
        {
            counter = 0;
            isCounting = true;
            bannerTimer.SetActive(true);
        }
    }

    void CheckInput()
    {
        //to join
        for (int i = 1; i < Players.Length+1; ++i)
        {
            if (!activePlayers.Contains(i) && Input.GetButtonDown("SelectP" + i))
            {
                activePlayers.Add(i);
                Players[GetPlayer()].Active(i);
            }
        }

        //to back out
        for (int i = 1; i < 5; ++i)
        {
            if (activePlayers.Contains(i) && Input.GetButtonDown("BackoutP" + i))
            {
                activePlayers.Remove(i);
                DeactivePlayer(i);
            }
        }
    }

    int GetPlayer()
    {
        for (int i = 0; i < Players.Length; ++i)
        {
            if (!Players[i].enabled)
            {
                return i;
            }
        }
        return 0;
    }

    void DeactivePlayer(int ctrl)
    {
        for (int i = 0; i < Players.Length; ++i)
        {
            if (Players[i].enabled && Players[i].controllerID.Equals(ctrl))
            {
                Players[i].DeActive();
                return;
            }
        }
    }
}
