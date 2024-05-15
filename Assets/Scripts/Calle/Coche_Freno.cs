using UnityEngine;

public class Coche_Freno : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del coche
    public float destination = 10f; // Posici�n de destino del coche
    public float brakeDistance = 2f; // Distancia restante desde el destino donde el coche debe frenar
    public bool moveUpwards = true; // Indica si el coche se mueve hacia arriba o hacia abajo
    private Vector3 originalPosition; // Posici�n original del coche
    private bool moving = true; // Indica si el coche est� en movimiento
    private bool braking = false; // Indica si el coche est� frenando
    private float brakeStartDistance; // Distancia desde el destino donde comienza el frenado
    public float tiempoHastaAparecer = 10f;

    public Animator animator; // Referencia al componente Animator del coche
    public string nombreAnimacion;

    void Start()
    {
        originalPosition = transform.position; // Almacenamos la posici�n original del coche
        brakeStartDistance = destination - brakeDistance; // Calculamos la distancia desde el destino donde comienza el frenado

        animator.Play(nombreAnimacion);
    }

    void Update()
    {
        if (Time.time >= tiempoHastaAparecer)
        {
            // Si el coche est� en movimiento
            if (moving)
            {
                // Movimiento del coche hacia el destino
                if (moveUpwards)
                {
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector2.down * speed * Time.deltaTime);
                }

                // Si el coche est� cerca del destino y no ha comenzado a frenar, iniciar el frenado
                if (!braking && Mathf.Abs((moveUpwards ? transform.position.y : originalPosition.y - transform.position.y) - brakeStartDistance) <= 0.1f)
                {
                    StartBraking();
                }

                // Si el coche llega al destino, detener el movimiento
                if (Mathf.Abs((moveUpwards ? transform.position.y : originalPosition.y - transform.position.y) - destination) <= 0.1f)
                {
                    StopCar();
                }
            }
            // Si el coche est� frenando
            else if (braking)
            {
                // Calcular la velocidad de frenado gradual
                float currentBrakeSpeed = Mathf.Lerp(speed, 0f, Mathf.Abs((moveUpwards ? transform.position.y : originalPosition.y - transform.position.y) - brakeStartDistance) / brakeDistance);
                //Debug.Log(currentBrakeSpeed);
                //Debug.Log(currentBrakeSpeed);
                // Aplicar el frenado gradual
                if (moveUpwards)
                {
                    transform.Translate(Vector2.up * currentBrakeSpeed * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector2.down * currentBrakeSpeed * Time.deltaTime);
                }

                // Si el coche se detiene completamente, detener el frenado
                if (currentBrakeSpeed <= 0.5f)
                {
                    braking = false;
                }
            }
        }
    }

    // M�todo para iniciar el frenado gradual
    void StartBraking()
    {
        braking = true;
        moving = false;
        //Debug.Log("Frenando");
    }

    // M�todo para detener el movimiento del coche
    void StopCar()
    {
        braking = false;
    }
}
