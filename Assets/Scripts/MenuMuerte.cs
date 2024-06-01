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
        // Aseguramos que el menú de pausa esté desactivado al inicio
        pantallaMuerte.SetActive(true);
        pantallaMuerte.SetActive(false);
        Debug.Log("Entro en script muerte");
    }

    void Update()
    {
        Debug.Log(GameManager.Instance.vidas);
        if (GameManager.Instance != null && GameManager.Instance.vidas <= 0)
        {

            Debug.Log("Intento lanzar pantalla muerte");
            PantallaMuerte();
        }
        else if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance es null");
        }
    }

    public void PantallaMuerte()
    {
        Debug.Log("Entro en pantalla muerte");
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
        pantallaMuerte.SetActive(false);  // Desactivamos el menú de pausa
        Time.timeScale = 1f;  // Reanudamos el juego
        Debug.Log("Juego reanudado y menú de pausa desactivado");
        GameManager.Instance.vidas = 6;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}

