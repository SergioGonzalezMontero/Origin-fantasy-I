using UnityEngine;

public class DañoPorColision : MonoBehaviour
{
  [SerializeField] UIManager uiManager;
    private void Start()
    {
       
    }



    private void OnCollisionEnter(Collision collision)
    {
        // Verifica si la colisión es con un objeto NPC
        if (collision.collider.CompareTag("NPC"))
        {         
            Debug.Log("COLISION CON NPC");
            // Llama al método ActualizarVidaUI del UIManager
            // Pasando como argumento la cantidad de vida a actualizar
            uiManager.ActualizarVidaUI(2); // Ejemplo: Restar una vida
        }
    }
}