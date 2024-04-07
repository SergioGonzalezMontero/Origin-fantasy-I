using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe_Mov : MonoBehaviour
{
    private BoxCollider2D colGolpe;

    private void Awake()
    {
        colGolpe = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Enemigo")){
            Destroy(otro.gameObject);
            Debug.Log("Golpeado");
        }
        else if (otro.CompareTag("Activable"))
        {
            Debug.Log("Interruptor Activado");
        }
    }
}
