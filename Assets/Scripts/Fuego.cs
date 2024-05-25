using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : MonoBehaviour
{

    int veces = 0;
    public float tiempoDaño;
    private bool nuevaQuemadura = false;
    private GameObject playerRef;
    // Start is called before the first frame update
    void Start()
    {
        tiempoDaño = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag== "Player")
        {
            veces++;
            Debug.Log("Quemado "+ veces);
            playerRef = other.gameObject;
            other.gameObject.GetComponent<Per_Movimiento>().DanoJugador(1);
            StartCoroutine(newQuemaduraCorrutina());
        }
    }
    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        if (nuevaQuemadura)
    //        {
    //            nuevaQuemadura = false;
    //            playerRef = other.gameObject;
    //            StartCoroutine(newQuemaduraCorrutina());
    //        }
    //    }
    //}
    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        StopAllCoroutines();
    //    }
    //}

    IEnumerator newQuemaduraCorrutina()
    {
        yield return new WaitForSeconds(tiempoDaño);
        nuevaQuemadura = true;
        playerRef.GetComponent<Per_Movimiento>().DanoJugador(1);
    }
}
