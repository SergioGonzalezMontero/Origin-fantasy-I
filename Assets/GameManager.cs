using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int vidas = 6;

    public bool[] niveles;

    public int nivelMax = 0;

    public bool ComienzoJuego = true;

    public GameObject pantallaMuerte;




    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            pantallaMuerte.SetActive(false);
}

        else
        {
            Destroy(this.gameObject);
        }
            
        DontDestroyOnLoad(this);
    }
    public void GameOver()
    {
        Debug.Log("GameOver");
        vidas = 0;

        pantallaMuerte.SetActive(true);
        Time.timeScale = 0f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
