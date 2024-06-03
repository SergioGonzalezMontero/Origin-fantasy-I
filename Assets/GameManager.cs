using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int vidas = 6;

    public bool[] niveles;

    public int nivelMax = 0;

    public bool ComienzoJuego = true;

    public GameObject pantallaMuerte;

    public int nota = 10;

    public AudioSource musicaInicio;

    public AudioSource musicaPausa;

    public AudioSource musicaJuego;




    // public void Update()
    // {
    //     if (vidas > 0)
    //     {
    //         pantallaMuerte.SetActive(false);
    //     }
    // }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            pantallaMuerte.SetActive(false);
}

        else
        {
            Destroy(this.gameObject);
        }
            
        DontDestroyOnLoad(this);
    }

    public GameObject GetPantallaMuerte()
    {
        return pantallaMuerte;
    }

    public void GameOver(GameObject pantallaMuerte)
    {
        Debug.Log("GameOver");
        vidas = 0;
        
        
        if (nota > 0)
        {
            nota--;
        }
        Debug.Log("Baja la nota, nota actual: " + nota);
        if (pantallaMuerte != null)
        {
            pantallaMuerte.SetActive(true);
        }
            
        Time.timeScale = 0f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
