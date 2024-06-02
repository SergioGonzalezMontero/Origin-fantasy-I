using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour
{
    public GameObject pantallaMuerte;
    private bool muerto = false;  // Inicializamos pausado como false
    private GameObject UI;

    void Start()
    {
        // Aseguramos que el men� de pausa est� desactivado al inicio
        pantallaMuerte.SetActive(true);
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("-. MenuPrincipal");
    }

    public void VolverAlJuego()
    {
        muerto = false;
        pantallaMuerte.SetActive(false);  // Desactivamos el men� de pausa
        Time.timeScale = 1f;  // Reanudamos el juego
        Debug.Log("Juego reanudado y men� de pausa desactivado");
        GameManager.Instance.vidas = 6;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}

