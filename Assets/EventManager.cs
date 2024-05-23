using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //Evento1
    public GameObject manguera;
    public GameObject[] Autos;

    //Evento2
    public GameObject manuel_pasar;

    public void newEvent(string eventCode)
    {
        Debug.Log("NewEvent: " + eventCode);
        switch (eventCode)
        {
            case "manguera":
                if(manguera != null)
                {
                    manguera.SetActive(false);
                    StartCoroutine(LevelManager.instance.managerUI.nuevaTransicion());
                }
                break;
            case "auto":
                if(Autos != null)
                {
                    for (int a = 0; a < Autos.Length; a++)
                    {
                        if (Autos[a] == null)
                            return;
                        Autos[a].SetActive(false);
                    }
                    StartCoroutine(LevelManager.instance.managerUI.nuevaTransicion());
                }
                break;

            case "manuel_pasar":
                if(manuel_pasar!= null)
                {
                    manuel_pasar.SetActive(false);
                }
                break;
        }
    }
    public void setLevel(int id)
    {
        switch (id)
        {
            case 0:
                break;
            case 1:
                for (int a = 0; a < Autos.Length; a++)
                {
                    Autos[a].SetActive(false);
                }
                manguera.SetActive(false);
                break;
            case 2:
                manuel_pasar.SetActive(false);
                break;

        }
    }
}
