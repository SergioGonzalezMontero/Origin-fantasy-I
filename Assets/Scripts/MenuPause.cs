using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject pantallaPausa;
    private bool pausado = false;  // Inicializamos pausado como false

    void Start()
    {
        // Aseguramos que el menú de pausa esté desactivado al inicio
        pantallaPausa.SetActive(false);
    }

    void Update()
    {

            // Detecta si se ha presionado la tecla Escape
            if (Input.GetKeyDown(KeyCode.Escape)&&GameManager.Instance.vidas>0)
            {
                Debug.Log("Pulso botón esc");
                TogglePause();

        }

    }

    public void TogglePause()
    {
        pausado = !pausado;  // Cambiamos el estado de pausado

        if (pausado)
        {
            pantallaPausa.SetActive(true);  // Activamos el menú de pausa
            Time.timeScale = 0f;  // Pausamos el juego
            Debug.Log("Juego pausado y menú de pausa activado");
        }
        else
        {
            pantallaPausa.SetActive(false);  // Desactivamos el menú de pausa
            Time.timeScale = 1f;  // Reanudamos el juego
            Debug.Log("Juego reanudado y menú de pausa desactivado");
        }
    }

    public void VolverMenuPrincipal()
    {
        // Reanudamos el tiempo antes de cambiar de escena
        Time.timeScale = 1f;
        SceneManager.LoadScene("-. MenuPrincipal");
    }

    public void VolverAlJuego()
    {
        pausado = false;
        pantallaPausa.SetActive(false);  // Desactivamos el menú de pausa
        Time.timeScale = 1f;  // Reanudamos el juego
        Debug.Log("Juego reanudado y menú de pausa desactivado");
    }
}