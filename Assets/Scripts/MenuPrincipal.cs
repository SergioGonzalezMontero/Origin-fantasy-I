using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuPrincipal : MonoBehaviour
{

    public string primeraEscena;
    public VideoPlayer video;



    void Start()
    {
        if(video != null)
        {
            video = GetComponent<VideoPlayer>();
            video.isLooping = true;
            video.Play();
        }
        if (GameManager.Instance.musicaInicio != null)
        {
            GameManager.Instance.musicaInicio.Play();
        }


    }
    public void EmpezarJuego()
    {
        if (GameManager.Instance.musicaInicio != null)
        {
            GameManager.Instance.musicaInicio.Stop();
        }
        if (GameManager.Instance.musicaJuego != null)
        {
            GameManager.Instance.musicaJuego.Play();
        }

        SceneManager.LoadScene(primeraEscena);
        


    }

    public void SalirJuego()
    {
        Application.Quit();

    }
}
