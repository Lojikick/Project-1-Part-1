using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTriggerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll){
        if (coll.CompareTag("Player"))
        {
        GameObject hm = GameObject.FindWithTag("GameController");
        //hm.GetComponent<GameManager>().WinGame();//
    }
    }
    
}
