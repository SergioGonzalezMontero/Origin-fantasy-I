using UnityEngine;

public class Autobus : MonoBehaviour
{
    public float initialSpeed = 0f; // Velocidad inicial (ser� 0 para arrancar progresivamente)
    public float maxSpeed = 5f; // Velocidad m�xima de movimiento del autob�s
    public float accelerationTime = 2f; // Tiempo en segundos para alcanzar la velocidad m�xima
    public float delayInSeconds = 3f; // Tiempo de retardo en segundos antes de que el autob�s arranque
    public float disappearAfterSeconds = 10f; // Tiempo en segundos despu�s del cual el autob�s desaparecer�
    private bool moving = false; // Indica si el autob�s est� en movimiento
    private float currentSpeed = 0f; // Velocidad actual del autob�s
    private float accelerationRate; // Tasa de aceleraci�n del autob�s

    public Animator animator;

    void Start()
    {
        if (GameManager.Instance.nota != 10)
        {
            Disappear();
        }
        // Calcular la tasa de aceleraci�n
        accelerationRate = maxSpeed / accelerationTime;

        // Iniciar el autob�s despu�s del retardo
        Invoke("StartMoving", delayInSeconds);
    }

    void Update()
    {
        // Si el autob�s est� en movimiento, desplazarlo
        if (moving)
        {
            // Incrementar la velocidad gradualmente hasta alcanzar la velocidad m�xima
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += accelerationRate * Time.deltaTime;
                if (currentSpeed > maxSpeed)
                {
                    currentSpeed = maxSpeed;
                }
            }

            // Mover el autob�s hacia abajo
            transform.Translate(Vector2.down * currentSpeed * Time.deltaTime);
        }
    }

    void StartMoving()
    {
        animator.SetTrigger("Arranca");

        moving = true;
        currentSpeed = initialSpeed; // Comenzar con la velocidad inicial
        // Hacer desaparecer el autob�s despu�s del tiempo especificado
        Invoke("Disappear", disappearAfterSeconds);
    }

    void Disappear()
    {
        Destroy(gameObject);
    }
}
