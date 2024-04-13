using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globo : MonoBehaviour
{
    public delegate void SumaGlobo(int globo);
    public static event SumaGlobo sumaGlobo;

    [SerializeField] private int cantidadGlobos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tocar"))
        {
            if(sumaGlobo != null)
            {
                SumarGlobo();
                Destroy(this.gameObject);
            }
        }
    }

    private void SumarGlobo()
    {
        sumaGlobo(cantidadGlobos);
    }
}
