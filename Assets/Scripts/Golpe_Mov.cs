using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe_Mov : MonoBehaviour
{
    private BoxCollider2D colGolpe;
    public Contr_Nevera contr_nevera;
    private int cont = 0;

    private void Awake()
    {
        contr_nevera = FindAnyObjectByType<Contr_Nevera>();
        colGolpe = GetComponentInParent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Enemigo")){
            Destroy(otro.gameObject);
            Debug.Log("Golpeado");
        }
        else if (otro.CompareTag("Activable"))
        {
            cont = cont + 1;
            //Debug.Log(cont);
            contr_nevera.Activado();
        }
    }
}
