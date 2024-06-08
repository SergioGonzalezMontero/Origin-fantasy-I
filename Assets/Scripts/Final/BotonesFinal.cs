using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesFinal : MonoBehaviour
{

    public void VolverInicio()
    {
        SceneManager.LoadScene(0);
    }
    
    
    public void SalirJuego()
    {
        Application.Quit();

    }
}
