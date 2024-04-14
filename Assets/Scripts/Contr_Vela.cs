using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contr_Vela : MonoBehaviour
{
    [SerializeField] Per_Movimiento per_Movimiento;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tocar"))
        {
            per_Movimiento.ActualizarVida(false, 1);
        }
    }
}
