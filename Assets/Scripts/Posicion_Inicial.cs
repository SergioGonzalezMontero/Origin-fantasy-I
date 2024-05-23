using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Posicion_Inicial : MonoBehaviour
{
    public Transform Inicio1;
    public Transform Inicio2;
    public Transform Inicio3;
    public static bool ComienzoJuego = true;

    private void Start()
    {
        string escenaAnterior = PlayerPrefs.GetString("EscenaAnterior");

        // Determinar la posicion inicial del jugador segun la escena anterior
        Debug.Log(escenaAnterior);
        switch (escenaAnterior)
        {
            case "Calle":
                transform.position = Inicio1.position;
                break;
            case "Entrada":
                if (SceneManager.GetActiveScene().name.ToString().Equals("Calle"))
                {
                    Debug.Log(ComienzoJuego);
                    if (ComienzoJuego)
                    {
                        transform.position = Inicio1.position;
                        ComienzoJuego = false;
                    }
                    else
                    {
                        transform.position = Inicio2.position;
                    }
                }
                else if (SceneManager.GetActiveScene().name.ToString().Equals("Patio_Inferior"))
                {
                    transform.position = Inicio1.position;
                }
                break;
            case "Patio_Inferior":
                if (SceneManager.GetActiveScene().name.ToString().Equals("Entrada"))
                {
                    transform.position = Inicio2.position;
                }
                else if (SceneManager.GetActiveScene().name.ToString().Equals("Patio_Superior"))
                {
                    transform.position = Inicio1.position;
                    
                }
                break;
            case "Patio_Superior":
                if (SceneManager.GetActiveScene().name.ToString().Equals("Patio_Inferior"))
                {
                    transform.position = Inicio2.position;
                }
                else if (SceneManager.GetActiveScene().name.ToString().Equals("EdificioC_P0"))
                {
                    transform.position = Inicio1.position;
                }
                break;
            case "EdificioC_P0":
                if (SceneManager.GetActiveScene().name.ToString().Equals("Patio_Superior"))
                {
                    transform.position = Inicio2.position;
                }else if (SceneManager.GetActiveScene().name.ToString().Equals("EdificioC_C0"))
                {
                    transform.position = Inicio1.position;
                }else if (SceneManager.GetActiveScene().name.ToString().Equals("EdificioC_P1"))
                {
                    transform.position = Inicio1.position;
                }
                break;
            case "EdificioC_C0":
                transform.position = Inicio2.position;

                break;
            case "EdificioC_P1":
                if (SceneManager.GetActiveScene().name.ToString().Equals("EdificioC_P0"))
                {
                    transform.position = Inicio3.position;
                }
                else if (SceneManager.GetActiveScene().name.ToString().Equals("EdificioC_C1"))
                {
                    transform.position = Inicio1.position;
                }
                break;
        }
    }
}
