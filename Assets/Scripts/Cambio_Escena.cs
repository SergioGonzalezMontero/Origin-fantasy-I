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
                
                case "0. Calle":
                    //Debug.Log("Entro en Case para activar escena 0. Calle");
                    //SceneManager.LoadScene("1. Entrada");
                    
                    StartCoroutine(DesvanecerYTransicionar("1. Entrada"));

                    break;
                case "1. Entrada":
                    Debug.Log("Entro en Case para activar escena 1. Entrada");
                    if (num_Escena == 1)
                    {
                        //StartCoroutine(LevelManager.instance.managerUI.antesNuevaTransicion());
                        //SceneManager.LoadScene("0. Calle");
                        //StartCoroutine(LevelManager.instance.managerUI.nuevaTransicion());
                        StartCoroutine(DesvanecerYTransicionar("0. Calle"));

                    } else if(num_Escena == 2) 
                    {
                        //StartCoroutine(LevelManager.instance.managerUI.antesNuevaTransicion());
                        //SceneManager.LoadScene("2. Patio_Inferior");
                        //StartCoroutine(LevelManager.instance.managerUI.nuevaTransicion());
                        StartCoroutine(DesvanecerYTransicionar("2. Patio_Inferior"));
                    }
                    
                    break;
                case "2. Patio_Inferior":
                    if (num_Escena == 1)
                    {
                        //StartCoroutine(LevelManager.instance.managerUI.antesNuevaTransicion());
                        //SceneManager.LoadScene("1. Entrada");
                        //StartCoroutine(LevelManager.instance.managerUI.nuevaTransicion());
                        StartCoroutine(DesvanecerYTransicionar("1. Entrada"));
                    }
                    else if (num_Escena == 2)
                    {
                        //StartCoroutine(LevelManager.instance.managerUI.antesNuevaTransicion());
                        //SceneManager.LoadScene("3. Patio_Superior");
                        //StartCoroutine(LevelManager.instance.managerUI.nuevaTransicion());
                        StartCoroutine(DesvanecerYTransicionar("3. Patio_Superior"));
                    }

                    break;
                case "3. Patio_Superior":
                    if (num_Escena == 1)
                    {
                        //SceneManager.LoadScene("2. Patio_Inferior");
                        StartCoroutine(DesvanecerYTransicionar("2. Patio_Inferior"));
                    }
                    else if (num_Escena == 2)
                    {
                        //SceneManager.LoadScene("EdificioC_P0");
                        StartCoroutine(DesvanecerYTransicionar("4. Pasillo_Inferior"));
                    }

                    break;

                case "4. Pasillo_Inferior":
                    if (num_Escena == 1)
                    {
                      //  SceneManager.LoadScene("3. Patio_Superior");
                        StartCoroutine(DesvanecerYTransicionar("3. Patio_Superior"));

                    }
                    else if (num_Escena == 2)
                    {
                       // SceneManager.LoadScene("5. EdificioC_C0");
                        StartCoroutine(DesvanecerYTransicionar("5. EdificioC_C0"));
                    }
                    else if (num_Escena == 3)
                    {
                        //SceneManager.LoadScene("6. Pasillo_Superior");
                        StartCoroutine(DesvanecerYTransicionar("6. Pasillo_Superior"));
                    }

                    break;

                case "5. EdificioC_C0":

                    //SceneManager.LoadScene("4. Pasillo_Inferior");
                    StartCoroutine(DesvanecerYTransicionar("4. Pasillo_Inferior"));


                    break;

                case "6. Pasillo_Superior":
                    if (num_Escena == 1)
                    {
                        //SceneManager.LoadScene("4. Pasillo_Inferior");
                        StartCoroutine(DesvanecerYTransicionar("4. Pasillo_Inferior"));

                    }
                    else if (num_Escena == 2)
                    {
                        //SceneManager.LoadScene("7. EdificioC_C1");
                        StartCoroutine(DesvanecerYTransicionar("7. EdificioC_C1"));
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
