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

            PlayerPrefs.SetString("EscenaAnterior", SceneManager.GetActiveScene().name);
            PlayerPrefs.Save();
            if(LevelManager.instance.nivelNum < num_Escena)
                GameManager.Instance.niveles[LevelManager.instance.nivelNum] = true;
            switch (SceneManager.GetActiveScene().name.ToString())
            {
                case "Calle":
                    SceneManager.LoadScene("Entrada");

                    break;
                case "Entrada":
                    if(num_Escena == 1)
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
