using UnityEngine;
using System.Collections;

public class BalonFutbol : MonoBehaviour
{
    public float fuerzaDisparo = 5000f; // Fuerza del disparo
    public float distanciaRecorrido = 5f; // Distancia que el balón recorrerá al ser chocado
    private Rigidbody2D rb;
    private float minX = -8f;
    private float maxX = 2.5f;
    private float minY = -21f;
    private float maxY = -19f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    
    }

    void Update()
    {
        Vector2 posición = transform.position;
        posición.x = Mathf.Clamp(posición.x, minX, maxX);
        posición.y = Mathf.Clamp(posición.y, minY, maxY);
        transform.position = posición;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC")) // Verificar si el balón no ha sido chocado y si colisionó con un NPC
        {
            
            Vector2 direcciónEmpuje = (other.transform.position - transform.position).normalized;

            // Calcular el punto final del recorrido
            Vector2 puntoFinal = rb.position - direcciónEmpuje * distanciaRecorrido;

            // Limitar el punto final dentro de los límites establecidos
            StartCoroutine(RecorrerDistancia(puntoFinal)); // Iniciar la coroutine para recorrer la distancia
        }
    }

    IEnumerator RecorrerDistancia(Vector2 puntoFinal)
    {
        float distancia = Vector2.Distance(rb.position, puntoFinal); // Calcular la distancia restante
        while (distancia > 0.1f) // Mientras la distancia restante sea mayor que un pequeño umbral
        {
            // Mover gradualmente el balón hacia el punto final
            rb.position = Vector2.MoveTowards(rb.position, puntoFinal, Time.deltaTime);
            distancia = Vector2.Distance(rb.position, puntoFinal); // Recalcular la distancia restante
            yield return null;
        }
        // Reiniciar la variable chocado para permitir que el balón sea chocado nuevamente
    }
}
