using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contr_ZonaDialogo : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.enabled = false;
        }
    }

}
