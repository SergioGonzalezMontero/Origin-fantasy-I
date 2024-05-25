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

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
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
        vidas = 6;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
