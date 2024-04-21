using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteractable : MonoBehaviour
{
    public Textos textos;

    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (spriteRenderer.isVisible)
        {
            FindObjectOfType<ControlDialogos>().ActivarCartel(textos);
            spriteRenderer.enabled = false;
        }
        
    }

    //private void Update()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        FindObjectOfType<ControlDialogos>().ActivarCartel(textos);
    //    }
    //}
}
