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
        Debug.Log("Entro en script muerte");
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
        Time.timeScale = 1f;
        pantallaMuerte.SetActive(false);
        GameManager.Instance.vidas = 6;
        SceneManager.LoadScene("-. MenuPrincipal");
    }

    public void VolverAlJuego()
    {
        muerto = false;
        pantallaMuerte.SetActive(false);  // Desactivamos la pantalla de muerte
        Time.timeScale = 1f;  // Reanudamos el juego
        Debug.Log("Juego reanudado y menú de muerte desactivado");
        GameManager.Instance.vidas = 6;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
