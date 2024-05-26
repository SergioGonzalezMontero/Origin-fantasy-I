using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contr_Mov_NPC : MonoBehaviour
{

    [Header("Parametros")]
    public bool bucle = false;
    public List<Movimiento> movimientos;
    
    private Animator animator;
    private int indiceActual = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(EjecutarMovimientos());
    }

    private IEnumerator EjecutarMovimientos()
    {
        while (true) // Bucle infinito para manejar la repetición
        {
            while (indiceActual < movimientos.Count)
            {
                Movimiento movimiento = movimientos[indiceActual];
                yield return StartCoroutine(MoverNPC(movimiento));
                indiceActual++;
            }

            if (bucle)
            {
                indiceActual = 0; // Volver al primer movimiento
            }
            else
            {
                break; // Salir del bucle si no se debe repetir
            }
        }
    }

    private IEnumerator MoverNPC(Movimiento movimiento)
    {
        animator.Play(Convert.ToString(movimiento.animacion));

        Vector3 direccion = Vector3.zero;

        switch (movimiento.direccion)
        {
            case Direccion.Arriba:
                direccion = Vector3.up;
                break;
            case Direccion.Abajo:
                direccion = Vector3.down;
                break;
            case Direccion.Izquierda:
                direccion = Vector3.left;
                break;
            case Direccion.Derecha:
                direccion = Vector3.right;
                break;
        }

        float tiempoTranscurrido = 0;
        Vector3 posicionInicial = transform.position;
        Vector3 posicionObjetivo = posicionInicial + (direccion * movimiento.velocidad * movimiento.duracion);

        while (tiempoTranscurrido < movimiento.duracion)
        {
            transform.position = Vector3.Lerp(posicionInicial, posicionObjetivo, tiempoTranscurrido / movimiento.duracion);
            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }

        transform.position = posicionObjetivo;

        // Pausa entre movimientos
        yield return new WaitForSeconds(movimiento.espera); // Ajusta el tiempo de pausa según sea necesario
    }
}
