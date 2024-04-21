using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ControlDialogos : MonoBehaviour
{
    public Animator anim;
    private Queue<string> colaDialogos = new Queue<string>();
    Textos texto;
    [SerializeField] TextMeshProUGUI textoPantalla;

    public GameObject cartel;

    public void ActivarCartel(Textos textoObjeto)
    {
        Debug.Log("ActivarCartel");

        Per_Movimiento.interactuando = true;

        anim.SetTrigger("Entrar");
        cartel.SetActive(true);
        texto = textoObjeto;
        ActivaTexto();
    }

    public void ActivaTexto() 
    {
        Debug.Log("ActivaTexto");

        colaDialogos.Clear();
        foreach (string textoGuardar in texto.arrayTextos)
        {
            Console.WriteLine(colaDialogos.Count);
            Debug.Log("ActivaTexto");
            colaDialogos.Enqueue(textoGuardar);
        }
        SiguienteFrase();
    }

    public void SiguienteFrase()
    {
        Debug.Log("SiguienteFrase");

        if (colaDialogos.Count == 0)
        {
            CierraCartel();
            return;
        }

        string fraseActual = colaDialogos.Dequeue();
        textoPantalla.text = fraseActual;
    }

    void CierraCartel()
    {
        Debug.Log("CierraCartel");

        anim.SetTrigger("Salir");
    }


    public void DesactivarCartel()
    {
        Debug.Log("DesactivarCartel");

        cartel.SetActive(false);

        Per_Movimiento.interactuando = false;
    }
}
