using UnityEngine;

public class Autobus : MonoBehaviour
{
    public float initialSpeed = 0f; // Velocidad inicial (será 0 para arrancar progresivamente)
    public float maxSpeed = 5f; // Velocidad máxima de movimiento del autobús
    public float accelerationTime = 2f; // Tiempo en segundos para alcanzar la velocidad máxima
    public float delayInSeconds = 3f; // Tiempo de retardo en segundos antes de que el autobús arranque
    public float disappearAfterSeconds = 10f; // Tiempo en segundos después del cual el autobús desaparecerá
    private bool moving = false; // Indica si el autobús está en movimiento
    private float currentSpeed = 0f; // Velocidad actual del autobús
    private float accelerationRate; // Tasa de aceleración del autobús

    public Animator animator;

    void Start()
    {
        if (GameManager.Instance.nota != 10)
        {
            Disappear();
        }
        // Calcular la tasa de aceleración
        accelerationRate = maxSpeed / accelerationTime;

        // Iniciar el autobús después del retardo
        Invoke("StartMoving", delayInSeconds);
    }

    void Update()
    {
        // Si el autobús está en movimiento, desplazarlo
        if (moving)
        {
            // Incrementar la velocidad gradualmente hasta alcanzar la velocidad máxima
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += accelerationRate * Time.deltaTime;
                if (currentSpeed > maxSpeed)
                {
                    currentSpeed = maxSpeed;
                }
            }

            // Mover el autobús hacia abajo
            transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);
        }
    }

    void StartMoving()
    {
        animator.SetTrigger("Arranca");

        moving = true;
        currentSpeed = initialSpeed; // Comenzar con la velocidad inicial
        // Hacer desaparecer el autobús después del tiempo especificado
        Invoke("Disappear", disappearAfterSeconds);
    }

    void Disappear()
    {
        Destroy(gameObject);
    }
}
