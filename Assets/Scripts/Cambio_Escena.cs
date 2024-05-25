using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambio_Escena : MonoBehaviour
{
    public int num_Escena;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Entro en colision para escena:");
            
           PlayerPrefs.SetString("EscenaAnterior", SceneManager.GetActiveScene().name);
           PlayerPrefs.Save();

            Debug.Log("Entro en cambio de escena num escena"+ LevelManager.instance.nivelNum);
           if (GameManager.Instance.nivelMax <= LevelManager.instance.nivelNum)
           {
               Debug.Log("Cambio numero de escena a" + num_Escena);
               GameManager.Instance.nivelMax = LevelManager.instance.nivelNum;
           }
           for (int i = 0; i< GameManager.Instance.nivelMax; i++)
           {
               GameManager.Instance.niveles[i] = true;
               Debug.Log("Completo los niveles: " + i);
           }
           if (LevelManager.instance.nivelNum < num_Escena) 
           {
               Debug.Log("Entro en cambiar instancia a true");
               GameManager.Instance.niveles[LevelManager.instance.nivelNum] = true;
               Debug.Log("Entro en escena");
               
           }
            Debug.Log("Voy a intentar entrar en Case para activar escena");
            switch (SceneManager.GetActiveScene().name.ToString())
            {
                
                case "Calle":
                    Debug.Log("Entro en Case para activar escena calle");
                    SceneManager.LoadScene("Entrada");

                    break;
                case "Entrada":
                    Debug.Log("Entro en Case para activar escena entrada");
                    if (num_Escena == 1)
                    {

                        SceneManager.LoadScene("Calle");
                    } else if(num_Escena == 2) 
                    {
                        SceneManager.LoadScene("Patio_Inferior");
                    }
                    
                    break;
                case "Patio_Inferior":
                    if (num_Escena == 1)
                    {
                        SceneManager.LoadScene("Entrada");
                    }
                    else if (num_Escena == 2)
                    {
                        SceneManager.LoadScene("Patio_Superior");
                    }

                    break;
                case "Patio_Superior":
                    if (num_Escena == 1)
                    {
                        SceneManager.LoadScene("Patio_Inferior");
                    }
                    else if (num_Escena == 2)
                    {
                        SceneManager.LoadScene("EdificioC_P0");
                    }

                    break;

                case "EdificioC_P0":
                    if (num_Escena == 4)
                    {
                        SceneManager.LoadScene("Patio_Superior");
                    }
                    else if (num_Escena == 5)
                    {
                        SceneManager.LoadScene("EdificioC_C1");
                    }else if (num_Escena == 6)
                    {
                        SceneManager.LoadScene("EdificioC_P1");
                    }

                    break;
            }
            
            
        }
    }
}
