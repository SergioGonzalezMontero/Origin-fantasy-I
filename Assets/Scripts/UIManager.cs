using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   
    private int totalGlobos;
    [SerializeField] private Text textoGlobos;
    [SerializeField] public List<Image> listaCorazones;
    [SerializeField] public Sprite corazonLleno, corazonMitad, corazonVacio;
    public GameObject transicion;
    
    void Start()
    {
        Globo.sumaGlobo += SumarGlobos;
        if(transicion != null)
            transicion.SetActive(false);
        ActualizarVidaUI(GameManager.Instance.vidas);
    }

    private void SumarGlobos(int globo)
    {
        totalGlobos += globo;
        textoGlobos.text = totalGlobos.ToString();
    }
    
    public void ActualizarVidaUI (int vida)
    {
        Debug.Log(vida);
        switch(vida){
            case 0:
                listaCorazones[0].sprite = corazonVacio;
                listaCorazones[1].sprite = corazonVacio;
                listaCorazones[2].sprite = corazonVacio;
                break;
            case 1:
                listaCorazones[0].sprite = corazonMitad;
                listaCorazones[1].sprite = corazonVacio;
                listaCorazones[2].sprite = corazonVacio;
                break;
            case 2:
                listaCorazones[0].sprite = corazonLleno;
                listaCorazones[1].sprite = corazonVacio;
                listaCorazones[2].sprite = corazonVacio;
                break;
            case 3:
                listaCorazones[0].sprite = corazonLleno;
                listaCorazones[1].sprite = corazonMitad;
                listaCorazones[2].sprite = corazonVacio;
                break;
            case 4:
                listaCorazones[0].sprite = corazonLleno;
                listaCorazones[1].sprite = corazonLleno;
                listaCorazones[2].sprite = corazonVacio;
                break;
            case 5:
                listaCorazones[0].sprite = corazonLleno;
                listaCorazones[1].sprite = corazonLleno;
                listaCorazones[2].sprite = corazonMitad;
                break;
            case 6:
                listaCorazones[0].sprite = corazonLleno;
                listaCorazones[1].sprite = corazonLleno;
                listaCorazones[2].sprite = corazonLleno;
                break;

        }
    }
    public IEnumerator nuevaTransicion()
    {
        if (transicion != null)
        {
            transicion.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            transicion.SetActive(false);
        }
    }
}
