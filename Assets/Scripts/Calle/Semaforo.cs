using UnityEngine;

public class Semaforo : MonoBehaviour
{
    public Animator animator; // Referencia al Animator del sem�foro
    public float delayInSeconds = 3f; // Tiempo de retardo en segundos antes de ejecutar la animaci�n

    void Start()
    {

        // Iniciar la animaci�n del sem�foro despu�s del retardo
        //Invoke("PlaySemaforoAnimation", delayInSeconds);
    }
}
