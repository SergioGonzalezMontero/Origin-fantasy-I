using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaFinal : MonoBehaviour
{
    public Animator animator;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("Abrir");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            animator.SetTrigger("Cerrar");
        }
    }
}
