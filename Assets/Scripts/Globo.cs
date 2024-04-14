using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globo : MonoBehaviour
{
    public delegate void SumaGlobo(int globo);
    public static event SumaGlobo sumaGlobo;

    [SerializeField] private int cantidadGlobos;
    [SerializeField] Per_Movimiento per_Movimiento;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tocar"))
        {
            if(sumaGlobo != null)
            {
                SumarGlobo();
                Destroy(this.gameObject);
                per_Movimiento.ActualizarVida(true, 2);
            }
        }
    }

    private void SumarGlobo()
    {
        sumaGlobo(cantidadGlobos);
    }
}
