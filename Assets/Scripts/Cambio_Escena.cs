using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cambio_Escena : MonoBehaviour
{
    public int num_Escena;

    public Image imagenTransicion;
    public float duracionDesvanecimiento = 1f;

    private void Awake()
    {
        if (imagenTransicion != null)
        {
            imagenTransicion.color = new Color(0, 0, 0, 0);
            imagenTransicion.gameObject.SetActive(true);
        }
    }

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
                    //Debug.Log("Entro en Case para activar escena calle");
                    //SceneManager.LoadScene("Entrada");

                    StartCoroutine(DesvanecerYTransicionar("Entrada"));

                    break;
                case "Entrada":
                    Debug.Log("Entro en Case para activar escena entrada");
                    if (num_Escena == 1)
                    {
                        //StartCoroutine(LevelManager.instance.managerUI.antesNuevaTransicion());
                        //SceneManager.LoadScene("Calle");
                        //StartCoroutine(LevelManager.instance.managerUI.nuevaTransicion());
                        StartCoroutine(DesvanecerYTransicionar("Calle"));

                    } else if(num_Escena == 2) 
                    {
                        //StartCoroutine(LevelManager.instance.managerUI.antesNuevaTransicion());
                        //SceneManager.LoadScene("Patio_Inferior");
                        //StartCoroutine(LevelManager.instance.managerUI.nuevaTransicion());
                        StartCoroutine(DesvanecerYTransicionar("Patio_Inferior"));
                    }
                    
                    break;
                case "Patio_Inferior":
                    if (num_Escena == 1)
                    {
                        //StartCoroutine(LevelManager.instance.managerUI.antesNuevaTransicion());
                        //SceneManager.LoadScene("Entrada");
                        //StartCoroutine(LevelManager.instance.managerUI.nuevaTransicion());
                        StartCoroutine(DesvanecerYTransicionar("Entrada"));
                    }
                    else if (num_Escena == 2)
                    {
                        //StartCoroutine(LevelManager.instance.managerUI.antesNuevaTransicion());
                        //SceneManager.LoadScene("Patio_Superior");
                        //StartCoroutine(LevelManager.instance.managerUI.nuevaTransicion());
                        StartCoroutine(DesvanecerYTransicionar("Patio_Superior"));
                    }

                    break;
                case "Patio_Superior":
                    if (num_Escena == 1)
                    {
                        //SceneManager.LoadScene("Patio_Inferior");
                        StartCoroutine(DesvanecerYTransicionar("Patio_Inferior"));
                    }
                    else if (num_Escena == 2)
                    {
                        //SceneManager.LoadScene("EdificioC_P0");
                        StartCoroutine(DesvanecerYTransicionar("Pasillo_Inferior"));
                    }

                    break;

                case "Pasillo_Inferior":
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

    public void TransicionarAEscena(string nombreEscena)
    {
        StartCoroutine(DesvanecerYTransicionar(nombreEscena));
    }

    private IEnumerator DesvanecerYTransicionar(string nombreEscena)
    {
        yield return StartCoroutine(Desvanecer());
        SceneManager.LoadScene(nombreEscena);
        yield return StartCoroutine(Aclarar());
    }

    private IEnumerator Desvanecer()
    {
        float tiempoTranscurrido = 0f;
        Color color = imagenTransicion.color;

        while (tiempoTranscurrido < duracionDesvanecimiento)
        {
            tiempoTranscurrido += Time.deltaTime;
            color.a = Mathf.Clamp01(tiempoTranscurrido / duracionDesvanecimiento);
            imagenTransicion.color = color;
            yield return null;
        }

        color.a = 1f;
        imagenTransicion.color = color;
    }

    private IEnumerator Aclarar()
    {
        float tiempoTranscurrido = 0f;
        Color color = imagenTransicion.color;

        while (tiempoTranscurrido < duracionDesvanecimiento)
        {
            tiempoTranscurrido += Time.deltaTime;
            color.a = 1f - Mathf.Clamp01(tiempoTranscurrido / duracionDesvanecimiento);
            imagenTransicion.color = color;
            yield return null;
        }

        color.a = 0f;
        imagenTransicion.color = color;
    }
}
