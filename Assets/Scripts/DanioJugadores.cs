using System.Collections;
using UnityEngine;

public class DanioJugadores : MonoBehaviour
{
    int veces = 0;
    public float tiempoDano;
    private bool nuevaQuemadura = true; // Iniciar como true para permitir el primer daño
    private GameObject playerRef;

    void Start()
    {
        tiempoDano = 5f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC") && nuevaQuemadura)
        {
            veces++;
            Debug.Log("Quemado " + veces);
            playerRef = other.gameObject;
            other.GetComponent<Per_Movimiento>().DanoJugador(1);
            nuevaQuemadura = false; // Desactivar la posibilidad de daño por un tiempo
            StartCoroutine(ReactivarQuemadura());
        }
    }

    IEnumerator ReactivarQuemadura()
    {
        yield return new WaitForSeconds(tiempoDano);
        nuevaQuemadura = true; // Reactivar la posibilidad de daño
    }
}