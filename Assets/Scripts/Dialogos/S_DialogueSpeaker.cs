using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DialogueSpeaker : MonoBehaviour
{
    public List<Conversacion> conversacionesDisponibles = new List<Conversacion>();

    [SerializeField]
    public int indexDeConversaciones = 0; //recorre cada conversacion dentro de la lsita de conversacionesDisponibles

    public int dialLocalIn = 0; //recorre cada dialogo de la conversacion actual

    public bool Activador;
    public Conversacion speakerActivador;

    void Start()
    {

        indexDeConversaciones = 0;
        dialLocalIn = 0;


        ///////////
        ////////////
        ///////////
        ///solo para pruebas, despues borrar
        //foreach(var conv in conversacionesDisponibles)
        //{
        //    conv.finalizado = false;
        //    var preg = conv.pregunta;
        //    if(preg != null)
        //    {
        //        foreach (var opcion in preg.opciones)
        //        {
        //            opcion.convResultante.finalizado = false;
        //        }
        //    }
        //}
       // ///solo para pruebas, despues borrar
         ///////////
        ////////////
        ///////////

    }
    /// 
    /// /////////////////////////////////////////////
    /// /////////////////////////////////////////////
    /// /////////////////////////////////////////////
    /////////////////////////////////////////////
    //IMPORTANTE PONERLE EL TAG PLAYER!!!!!!!!!!

    /////////////////////////////////////////////
    ////////////////////////////////////////////////
    ////////////////////////////////////////////////
    ////////////////////////////////////////////////
    ////////////////////////////////////////////////

    private bool playerInTrigger = false;
    public void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pulso E");
            Conversar();
        }

        if (playerInTrigger && Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Pulso Z");
            S_DialogoManager.instance.CambiarEstadoDeReUsable(conversacionesDisponibles[indexDeConversaciones], !conversacionesDisponibles[indexDeConversaciones].reUsar);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;

            S_DialogoManager.instance.MostrarUI(false);

        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;
            
        }
    }

    public void Conversar()
    {
        if (indexDeConversaciones <= conversacionesDisponibles.Count)
        {
            if (conversacionesDisponibles[indexDeConversaciones].desbloqueada)
            {
                Debug.Log("Entro: " + conversacionesDisponibles[indexDeConversaciones].desbloqueada + "Index: " + indexDeConversaciones);
                if (conversacionesDisponibles[indexDeConversaciones].finalizado)
                {
                    if (ActualizarConversacion())
                    {
                        Debug.Log("entro en actualizar conversacion");
                        S_DialogoManager.instance.MostrarUI(true);
                        S_DialogoManager.instance.SetConversacion(conversacionesDisponibles[indexDeConversaciones], this);
                        Debug.Log(conversacionesDisponibles[indexDeConversaciones]+"Conversaciones");
                        
                    }
                    S_DialogoManager.instance.SetConversacion(conversacionesDisponibles[indexDeConversaciones],this);
                    return;
                }
                S_DialogoManager.instance.MostrarUI(true);
                S_DialogoManager.instance.SetConversacion(conversacionesDisponibles[indexDeConversaciones], this);
                if(Activador)
                    speakerActivador.desbloqueada = true;
            }
            else
            {
                Debug.LogWarning("Conversacion Bloqueada");
                S_DialogoManager.instance.MostrarUI(false);
            }
        }
        else
        {
            Debug.Log("Fin del dialogo");
            //Ya se usaron todas las conversaciones disponibles
            print("Fin del dialogo");
            S_DialogoManager.instance.MostrarUI(false);
        }
    }

     bool ActualizarConversacion()
    {
        if (!conversacionesDisponibles[indexDeConversaciones].reUsar)
        {
            if(indexDeConversaciones < conversacionesDisponibles.Count - 1)
            {
                indexDeConversaciones++;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            conversacionesDisponibles[indexDeConversaciones].finalizado = false;
            return true;
        }
    }

   
   

}
