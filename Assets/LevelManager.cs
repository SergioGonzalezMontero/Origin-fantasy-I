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
        for (int i = 0; i < restart.Length; i++)
        {
            conversacion[i].desbloqueada = restart[i].desbloqueada;
            conversacion[i].finalizado = restart[i].finalizado;
            conversacion[i].reUsar = restart[i].reUsar;
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
