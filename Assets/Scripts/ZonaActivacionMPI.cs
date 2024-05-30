using System;
using UnityEngine;
using System.Collections;

public class ZoneTrigger : MonoBehaviour
{
    public Per_Movimiento movementScript1;
    public MecanicaPI movementScript2;
    private static int entraOsale = 1;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            movementScript1 = player.GetComponent<Per_Movimiento>();
            movementScript2 = player.GetComponent<MecanicaPI>();
        }
        else
        {
            Debug.LogError("No se pudo encontrar un GameObject con la etiqueta 'Player'");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DisableColliderTemporarily());

            entraOsale++;
            if (entraOsale % 2 == 0)
            {
                Debug.Log("Entra");
                movementScript1.enabled = false;
                movementScript2.enabled = true;
            }
            else
            {
                Debug.Log("Sale");
                movementScript1.enabled = true;
                movementScript2.enabled = false;
            }
            Debug.Log("El número es: " + entraOsale);

            // Reposiciona al jugador al lado opuesto del collider
            RepositionPlayer(other);

        }
    }

    void RepositionPlayer(Collider2D playerCollider)
    {
        // Obtenemos los límites del collider de la zona
        Bounds bounds = GetComponent<Collider2D>().bounds;
        Vector3 playerPosition = playerCollider.transform.position;

        // Reposiciona al jugador en el eje Y
        if (playerPosition.y < bounds.center.y)
        {
            // Si el jugador viene desde abajo, reposiciona arriba
            playerPosition.y = bounds.max.y + 1; // Ajusta '1' al espacio deseado entre el jugador y el collider
        }
        else
        {
            // Si el jugador viene desde arriba, reposiciona abajo
            playerPosition.y = bounds.min.y - 1; // Ajusta '1' al espacio deseado entre el jugador y el collider
        }

        // Asigna la nueva posición al transform del jugador
        playerCollider.transform.position = playerPosition;
    }

    IEnumerator DisableColliderTemporarily()
    {
        Collider2D collider = GetComponent<Collider2D>();
        if (collider != null)
        {
            // Desactiva el collider
            collider.enabled = false;

            // Espera medio segundo
            yield return new WaitForSeconds(1f);

            // Reactiva el collider
            collider.enabled = true;
        }
        else
        {
            Debug.LogError("No se encontró el Collider2D en el GameObject.");
        }
    }
}


