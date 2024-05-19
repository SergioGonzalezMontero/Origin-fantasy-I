using System.Collections.Generic;
using UnityEngine;

public class BalonFutbol : MonoBehaviour
{
    public float velocidadMovimiento = 4f;
    public float velocidadRotacion = 100f; // Velocidad de rotación

    private Vector2 dirección;
    private float minX = -12.62f;
    private float maxX = 3.95f;
    private float minY = -23.00f; // Reduciendo minY para hacer el rectángulo más delgado
    private float maxY = -17.30f;

    void Start()
    {
        dirección = ObtenerNuevaDirección();
    }

    void Update()
    {
        // Movimiento
        Vector2 movimiento = dirección * velocidadMovimiento * Time.deltaTime;
        Vector2 nuevaPosición = (Vector2)transform.position + movimiento;

        if (nuevaPosición.x < minX || nuevaPosición.x > maxX || nuevaPosición.y < minY || nuevaPosición.y > maxY)
        {
            // Si la nueva posición está fuera de los límites, obtenemos una nueva dirección
            dirección = ObtenerNuevaDirección();
        }
        else
        {
            // Si la nueva posición está dentro de los límites, movemos el objeto
            transform.Translate(movimiento, Space.World);

       
        }
    }

    Vector2 ObtenerNuevaDirección()
    {
        Vector2 nuevaDirección = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        return nuevaDirección;
    }
}
