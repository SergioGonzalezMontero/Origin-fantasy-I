using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractable : MonoBehaviour
{
    public Textos textos;

    private void OnMouseDown()
    {
        FindObjectOfType<ControlDialogos>().ActivarCartel(textos);
    }
}
