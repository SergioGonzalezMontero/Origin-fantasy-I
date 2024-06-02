using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject pantallaPausa;
    private bool pausado = false;  // Inicializamos pausado como false

    void Start()
    {
        // Aseguramos que el men� de pausa est� desactivado al inicio
        pantallaPausa.SetActive(false);
    }

    void Update()
    {

            // Detecta si se ha presionado la tecla Escape
            if (Input.GetKeyDown(KeyCode.Escape)&&GameManager.Instance.vidas>0)
            {
                Debug.Log("Pulso bot�n esc");
                TogglePause();

        }

    }

    public void TogglePause()
    {
        pausado = !pausado;  // Cambiamos el estado de pausado

        if (pausado)
        {
            pantallaPausa.SetActive(true);  // Activamos el men� de pausa
            Time.timeScale = 0f;  // Pausamos el juego
            Debug.Log("Juego pausado y men� de pausa activado");
        }
        else
        {
            pantallaPausa.SetActive(false);  // Desactivamos el men� de pausa
            Time.timeScale = 1f;  // Reanudamos el juego
            Debug.Log("Juego reanudado y men� de pausa desactivado");
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
        pantallaPausa.SetActive(false);  // Desactivamos el men� de pausa
        Time.timeScale = 1f;  // Reanudamos el juego
        Debug.Log("Juego reanudado y men� de pausa desactivado");
    }
}