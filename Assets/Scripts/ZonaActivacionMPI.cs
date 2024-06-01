using System;
using UnityEngine;
using System.Collections;

public class ZonaActivacionMPI : MonoBehaviour
{
    public Per_Movimiento movementScript1;
    public MecanicaPI movementScript2;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
       
            movementScript1 = player.GetComponent<Per_Movimiento>();
            movementScript2 = player.GetComponent<MecanicaPI>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
                Debug.Log("Entra");
                movementScript1.enabled = false;
                movementScript2.enabled = true;
        
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Sale");
            movementScript1.enabled = true;
            movementScript2.enabled = false;
        }
    }
}


