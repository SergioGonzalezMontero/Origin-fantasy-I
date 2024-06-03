using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Posicion_Inicial : MonoBehaviour
{
    public Transform Inicio1;
    public Transform Inicio2;
    public Transform Inicio3;
    

    private void Start()
    {
        string escenaAnterior = PlayerPrefs.GetString("EscenaAnterior");

        // Determinar la posicion inicial del jugador segun la escena anterior
        Debug.Log(escenaAnterior);
        switch (escenaAnterior)
        {
            case "0. Calle":
                transform.position = Inicio1.position;
                GameManager.Instance.ComienzoJuego = false;
                break;
            case "1. Entrada":
                if (SceneManager.GetActiveScene().name.ToString().Equals("0. Calle"))
                {
                    
                    if (GameManager.Instance.ComienzoJuego)
                    {
                        transform.position = Inicio1.position;
                        
                    }
                    else
                    {
                        transform.position = Inicio2.position;
                    }
                }
                else if (SceneManager.GetActiveScene().name.ToString().Equals("2. Patio_Inferior"))
                {
                    transform.position = Inicio1.position;
                }
                break;
            case "2. Patio_Inferior":

                if (SceneManager.GetActiveScene().name.ToString().Equals("1. Entrada"))
                {
                    transform.position = Inicio2.position;
                }
                else if (SceneManager.GetActiveScene().name.ToString().Equals("3. Patio_Superior"))
                {
                    transform.position = Inicio1.position;
                    
                }
                break;
            case "3. Patio_Superior":
                if (SceneManager.GetActiveScene().name.ToString().Equals("2. Patio_Inferior"))
                {
                    transform.position = Inicio2.position;
                }
                else if (SceneManager.GetActiveScene().name.ToString().Equals("4. Pasillo_Inferior"))
                {
                    transform.position = Inicio1.position;
                }
                break;
            case "4. Pasillo_Inferior":
                if (SceneManager.GetActiveScene().name.ToString().Equals("3. Patio_Superior"))
                {
                    transform.position = Inicio2.position;
                }else if (SceneManager.GetActiveScene().name.ToString().Equals("5. EdificioC_C0"))
                {
                    transform.position = Inicio1.position;
                }else if (SceneManager.GetActiveScene().name.ToString().Equals("6. Pasillo_Superior"))
                {
                    transform.position = Inicio1.position;
                }
                break;
            case "5. EdificioC_C0":
                Debug.Log("Entro en clase bien");
                transform.position = Inicio2.position;

                break;
            case "6. Pasillo_Superior":
                if (SceneManager.GetActiveScene().name.ToString().Equals("4. Pasillo_Inferior"))
                {
                    transform.position = Inicio3.position;
                }
                else if (SceneManager.GetActiveScene().name.ToString().Equals("7. EdificioC_C1"))
                {
                    transform.position = Inicio1.position;
                }
                break;
        }
    }
}
