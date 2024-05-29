using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    //Evento1
    public GameObject manguera;
    public GameObject[] Autos;

    //Evento2
    public GameObject[] manuel_pasar;

    public void newEvent(string eventCode)
    {
        Debug.Log("NewEvent: " + eventCode);
        switch (eventCode)
        {
            case "manguera":
                if (manguera != null)
                {
                    StartCoroutine(HandleMangueraEvent());
                }
                break;
            case "auto":
                if (Autos != null)
                {
                    StartCoroutine(HandleAutoEvent());
                }
                break;
            case "manuel_pasar":
                if (manuel_pasar != null)
                {
                    for (int i = 0; i < manuel_pasar.Length; i++)
                    {
                        manuel_pasar[i].SetActive(false);
                    }
                }
                break;
        }
    }

    private IEnumerator HandleMangueraEvent()
    {
        yield return StartCoroutine(LevelManager.instance.managerUI.antesNuevaTransicion());
        manguera.SetActive(false);
       // yield return StartCoroutine(esperarUnSeg());
        yield return StartCoroutine(LevelManager.instance.managerUI.nuevaTransicion());
    }

    private IEnumerator HandleAutoEvent()
    {
        yield return StartCoroutine(LevelManager.instance.managerUI.antesNuevaTransicion());
        for (int i = 0; i < Autos.Length; i++)
        {
            if (Autos[i] == null)
                yield break;
            Autos[i].SetActive(false);
        }
        //yield return StartCoroutine(esperarUnSeg());
        yield return StartCoroutine(LevelManager.instance.managerUI.nuevaTransicion());
    }

    public void setLevel(int id)
    {
        switch (id)
        {
            case 0:
                break;
            case 1:
                for (int i = 0; i < Autos.Length; i++)
                {
                    Autos[i].SetActive(false);
                }
                manguera.SetActive(false);
                break;
            case 2:
                for (int i = 0; i < manuel_pasar.Length; i++)
                {
                    manuel_pasar[i].SetActive(false);
                }
                break;
        }
    }

    IEnumerator esperarUnSeg()
    {
        Debug.Log("Esperando un segundo...");
        // Espera un segundo en tiempo real
        yield return new WaitForSecondsRealtime(1);
        Debug.Log("Un segundo ha pasado.");
    }
}
