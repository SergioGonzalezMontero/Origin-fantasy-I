using UnityEngine;

public class Semaforo : MonoBehaviour
{
    public Animator animator; // Referencia al Animator del semáforo
    public float delayInSeconds = 3f; // Tiempo de retardo en segundos antes de ejecutar la animación

    void Start()
    {

        // Iniciar la animación del semáforo después del retardo
        //Invoke("PlaySemaforoAnimation", delayInSeconds);
    }
}
