using UnityEngine;

public class Coche : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento de los coches
    public bool moveUpwards = true; // Indica si el coche se mueve hacia arriba o hacia abajo
    public float resetDistance = 10f; // Distancia desde la posición actual del coche donde se reinicia
    public float startDistance = 5f; // Distancia desde la posición reiniciada del coche donde comienza
    private Vector3 originalPosition; // Posición original del coche
    private Vector3 resetPosition; // Posición de reinicio del coche
    public float timeToDisappear = 10f; // Tiempo indicado antes de que el coche desaparezca después de llegar al final

    public Animator animator; // Referencia al componente Animator del coche
    public string nombreAnimacion;

    void Start()
    {
        timeToDisappear += Time.time;


        originalPosition = transform.position; // Almacenamos la posición original del coche
        resetPosition = originalPosition + (moveUpwards ? Vector3.up : Vector3.down) * resetDistance; // Calculamos la posición de reinicio del coche

        animator.Play(nombreAnimacion);
    }

    void Update()
    {
        // Movimiento del coche
        if (moveUpwards)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        // Si el coche ha alcanzado la posición de reinicio, volver a empezar
        if ((moveUpwards && transform.position.y >= resetPosition.y) || (!moveUpwards && transform.position.y <= resetPosition.y))
        {
            if (Time.time >= timeToDisappear)
            {
                gameObject.SetActive(false);
            }
            else
            {
                ReturnToStart();
            }
        }
    }

    // Método para volver al punto de inicio
    void ReturnToStart()
    {
        transform.position = resetPosition + (moveUpwards ? Vector3.up : Vector3.down) * startDistance; // Devolvemos el coche al punto de reinicio
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            reiniciar();
        }
    }

    private void reiniciar()
    {
        Debug.Log("matao");
        StartCoroutine(LevelManager.instance.managerUI.nuevaTransicion());
        GameManager.Instance.GameOver(GameManager.Instance.GetPantallaMuerte());
    }

}