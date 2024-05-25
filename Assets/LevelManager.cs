using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public UIManager managerUI;
    public EventManager eventManager;
    public int nivelNum;

    public Conversacion[] conversacion;
    public Restart[] restart;

    [System.Serializable]
    public struct Restart
    {
        public bool desbloqueada;
        public bool finalizado;
        public bool reUsar;
    }
    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    public void Start()
    {
        for (int a = 0; a < restart.Length; a++)
        {
            conversacion[a].desbloqueada = restart[a].desbloqueada;
            conversacion[a].finalizado = restart[a].finalizado;
            conversacion[a].reUsar = restart[a].reUsar;
        }
        if(GameManager.Instance.niveles[nivelNum])
        {
            eventManager.setLevel(nivelNum);
        }
            
    }
    public void newEvent(string _newEvent)
    {

        eventManager.newEvent(_newEvent);
    }
}
