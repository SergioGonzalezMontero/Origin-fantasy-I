using System.Collections.Generic;
using UnityEngine;

public class Random_Mov : MonoBehaviour
{
    public float velocidad = 4f;
    private Vector2 dirección;
    //public Animator animator;

    float minX = -12.62f;
    float maxX = 3.95f;
    float minY = -25.30f; 
    float maxY = -15.00f;

    void Start()
    {
        dirección = ObtenerNuevaDirección();
    }

    void Update()
    {

        Vector2 movimiento = dirección * velocidad * Time.deltaTime;
        Vector2 nuevaPosición = (Vector2)transform.position + movimiento;

        /*if (movimiento.x > 0f) // Movimiento hacia la derecha
        {
            animator.SetBool("isMovingRight", true);
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingUp", false);
            animator.SetBool("isMovingDown", false);
        }
        else if (movimiento.x < 0f) // Movimiento hacia la izquierda
        {
            animator.SetBool("isMovingRight", false);
            animator.SetBool("isMovingLeft", true);
            animator.SetBool("isMovingUp", false);
            animator.SetBool("isMovingDown", false);
        }
        else if (movimiento.y > 0f) // Movimiento hacia arriba
        {
            animator.SetBool("isMovingRight", false);
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingUp", true);
            animator.SetBool("isMovingDown", false);
        }
        else if (movimiento.y < 0f) // Movimiento hacia abajo
        {
            animator.SetBool("isMovingRight", false);
            animator.SetBool("isMovingLeft", false);
            animator.SetBool("isMovingUp", false);
            animator.SetBool("isMovingDown", true);
        }*/

        if (nuevaPosición.x < minX || nuevaPosición.x > maxX || nuevaPosición.y < minY || nuevaPosición.y > maxY)
        {
            // Si la nueva posición está fuera de los límites, obtenemos una nueva dirección
            dirección = ObtenerNuevaDirección();
        }
        else
        {
            // Si la nueva posición está dentro de los límites, movemos el objeto
            transform.Translate(movimiento);
        }
    }

    Vector2 ObtenerNuevaDirección()
    {
        Vector2 nuevaDirección = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        return nuevaDirección;
    }
}

