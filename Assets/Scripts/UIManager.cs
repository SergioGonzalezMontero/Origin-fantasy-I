using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int totalGlobos;
    [SerializeField] private Text textoGlobos;

    void Start()
    {
        Globo.sumaGlobo += SumarGlobos;
    }

    private void SumarGlobos(int globo)
    {
        totalGlobos += globo;
        textoGlobos.text = totalGlobos.ToString();
    }
}
