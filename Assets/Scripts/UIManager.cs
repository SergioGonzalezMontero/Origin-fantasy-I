using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int totalGlobos;
    [SerializeField] private Text textoGlobos;
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private Sprite corazonLleno, corazonMitad, corazonVacio;



    void Start()
    {
        Globo.sumaGlobo += SumarGlobos;
    }

    private void SumarGlobos(int globo)
    {
        totalGlobos += globo;
        textoGlobos.text = totalGlobos.ToString();
    }

    public void RestaCorazones (int indice)
    {

    }
}
