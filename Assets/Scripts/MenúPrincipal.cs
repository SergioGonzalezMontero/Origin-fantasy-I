using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenúPrincipal : MonoBehaviour
{

    public string primeraEscena;
    public void EmpezarJuego()
    {
        SceneManager.LoadScene(primeraEscena);
    }

    public void SalirJuego()
    {
        Application.Quit();

    }
}
