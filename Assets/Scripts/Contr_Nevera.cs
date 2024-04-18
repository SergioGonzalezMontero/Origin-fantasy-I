using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contr_Nevera : MonoBehaviour
{
    public ControlDialogos dialogos; 

    private Animator anim;

    private bool abierto = false;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Activado()
    {
        dialogos.ActivaTexto();
        if(abierto)
        {
            anim.SetBool("Abierto", false);
            abierto = false;
        }
        else
        {
            anim.SetBool("Abierto", true);
            abierto = true;
        }
    }
}
