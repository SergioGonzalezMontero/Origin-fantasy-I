using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{
    public GameObject pantallaMuerte;
    private bool muerto = false;  // Inicializamos pausado como false

    void Start()
    {
        // Aseguramos que el menú de pausa esté desactivado al inicio
        pantallaMuerte.SetActive(false);
        Debug.Log("Entro en script muerte");
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.vidas <= 0)
        {
            PantallaMuerte();
        }
        else if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance es null");
        }
    }

    public void PantallaMuerte()
    {
        if (!muerto)
        {
            muerto = true;  // Cambiamos el estado

            Debug.Log("se murio");
            pantallaMuerte.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void VolverMenuPrincipal()
    {
        // Reanudamos el tiempo antes de cambiar de escena
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void VolverAlJuego()
    {
        muerto = false;
        pantallaMuerte.SetActive(false);  // Desactivamos el menú de pausa
        Time.timeScale = 1f;  // Reanudamos el juego
        Debug.Log("Juego reanudado y menú de pausa desactivado");
    }
}

