using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{
    public GameObject pantallaMuerte;
    private bool muerto = false;  // Inicializamos como false

    void Start()
    {
        // Aseguramos que la pantalla de muerte esté desactivada al inicio
        pantallaMuerte.SetActive(false);
        
    }

    void Update()
    {
        if (GameManager.Instance != null)
        {
            if (GameManager.Instance.vidas <= 0)
            {
                if (!muerto)
                {
                    PantallaMuerte();
                }

            }
        }
        else
        {
            Debug.LogError("GameManager.Instance es null");
        }
    }

    public void PantallaMuerte()
    {
        if (!muerto)
        {
            if (GameManager.Instance.musicaJuego != null)
            {
                GameManager.Instance.musicaJuego.Stop();
            }
            if (GameManager.Instance.musicaPausa != null)
            {
                GameManager.Instance.musicaPausa.Play();
            }
            if (GameManager.Instance.musicaInicio != null)
            {
                GameManager.Instance.musicaInicio.Stop();
            }
            Debug.Log("Entro a lanzar la pantalla");
            muerto = true;  // Cambiamos el estado
            pantallaMuerte.SetActive(true);
            Debug.Log("se murio");
            Time.timeScale = 0f;
        }
    }

    public void VolverMenuPrincipal()
    {
        // Reanudamos el tiempo antes de cambiar de escena
        muerto = false;
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
        pantallaMuerte.SetActive(false);
        GameManager.Instance.vidas = 6;
        SceneManager.LoadScene("-. MenuPrincipal");
    }

    public void VolverAlJuego()
    {
        muerto = false;
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
        pantallaMuerte.SetActive(false);  // Desactivamos la pantalla de muerte
        Time.timeScale = 1f;  // Reanudamos el juego
        Debug.Log("Juego reanudado y menú de muerte desactivado");
        GameManager.Instance.vidas = 6;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
