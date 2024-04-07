using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contr_Nevera : MonoBehaviour
{
    private Animator anim;

    private bool abierto = false;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void Activado()
    {
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
