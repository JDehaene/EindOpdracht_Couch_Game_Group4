using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombBehaviour : MonoBehaviour {

    private bool _bombTriggered;
    private PlayerBehaviour BombPickup;
    private int _bossHealth = 6;
    public GameObject boss;
    public Text txtInfoBoss;

    private void Update()
    {
        BombTrigger();
        txtInfoBoss.text = "Boss has" + _bossHealth + " health left";

        if (_bossHealth <= 0)
            Destroy(boss);
    }

    void BombTrigger()
    {
        if(_bombTriggered)
        {
            _bossHealth--;
            Debug.Log(_bossHealth);
            Destroy(this.gameObject);
            
            _bombTriggered = false;           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _bombTriggered = true;
        }
    }

}
