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
        
    }
    public void EmpezarJuego()
    {
        SceneManager.LoadScene(primeraEscena);
    }

    public void SalirJuego()
    {
        Application.Quit();

    }
}
