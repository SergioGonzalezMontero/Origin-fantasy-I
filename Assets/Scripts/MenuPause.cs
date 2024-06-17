using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPause : MonoBehaviour
{
    public GameObject pantallaPausa;
    private bool pausado = false;  // Inicializamos pausado como false
    public TextMeshProUGUI textoNota;

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
            if (GameManager.Instance.musicaInicio != null)
            {
                GameManager.Instance.musicaInicio.Stop();
            }
            if (GameManager.Instance.musicaJuego != null)
            {
                GameManager.Instance.musicaJuego.Pause();
            }
            if (GameManager.Instance.musicaPausa != null)
            {
                GameManager.Instance.musicaPausa.Play();
            }
            textoNota.SetText("La nota actual es: "+GameManager.Instance.nota);
            pantallaPausa.SetActive(true);  // Activamos el menú de pausa
            Time.timeScale = 0f;  // Pausamos el juego
            Debug.Log("Juego pausado y menú de pausa activado");
        }
        else
        {
            if (GameManager.Instance.musicaInicio != null)
            {
                GameManager.Instance.musicaInicio.Stop();
            }
            if (GameManager.Instance.musicaJuego != null)
            {
                GameManager.Instance.musicaJuego.Play();
            }
            if (GameManager.Instance.musicaPausa != null)
            {
                GameManager.Instance.musicaPausa.Stop();
            }

            pantallaPausa.SetActive(false);  // Desactivamos el menú de pausa
            Time.timeScale = 1f;  // Reanudamos el juego
            Debug.Log("Juego reanudado y menú de pausa desactivado");
        }
    }

    public void VolverMenuPrincipal()
    {
        // Reanudamos el tiempo antes de cambiar de escena
        if (GameManager.Instance.musicaInicio != null)
        {
            GameManager.Instance.musicaInicio.Play();
        }
        if (GameManager.Instance.musicaJuego != null)
        {
            GameManager.Instance.musicaJuego.Stop();
        }
        if (GameManager.Instance.musicaPausa != null)
        {
            GameManager.Instance.musicaPausa.Stop();
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("-. MenuPrincipal");

    }

    public void VolverAlJuego()
    {
        pausado = false;
        if (GameManager.Instance.musicaInicio != null)
        {
            GameManager.Instance.musicaInicio.Stop();
        }
        if (GameManager.Instance.musicaJuego != null)
        {
            GameManager.Instance.musicaJuego.Play();
        }
        if (GameManager.Instance.musicaPausa != null)
        {
            GameManager.Instance.musicaPausa.Stop();
        }
        pantallaPausa.SetActive(false);  // Desactivamos el menú de pausa
        Time.timeScale = 1f;  // Reanudamos el juego
        Debug.Log("Juego reanudado y menú de pausa desactivado");
    }
}