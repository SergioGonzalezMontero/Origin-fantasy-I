using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DialogueSpeaker : MonoBehaviour
{

    public List<Conversacion> conversacionesDisponibles = new List<Conversacion>();

    [SerializeField]
    private int indexDeConversaciones = 0; //recorre cada conversacion dentro de la lsita de conversacionesDisponibles

    public int dialLocalIn = 0; //recorre cada dialogo de la conversacion actual

    void Start()
    {

        indexDeConversaciones = 0;
        dialLocalIn = 0;


        ///////////
        ////////////
        ///////////
        ///solo para pruebas, despues borrar
        foreach(var conv in conversacionesDisponibles)
        {
            conv.finalizado = false;
            var preg = conv.pregunta;
            if(preg != null)
            {
                foreach (var opcion in preg.opciones)
                {
                    opcion.convResultante.finalizado = false;
                }
            }
        }
        ///solo para pruebas, despues borrar
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

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")&& Input.GetKeyDown(KeyCode.E))
        {
            Conversar();
        }

        if(other.CompareTag("Player")&& Input.GetKeyDown(KeyCode.Z))
        {
            S_DialogoManager.instance.CambiarEstadoDeReUsable(conversacionesDisponibles[indexDeConversaciones], !conversacionesDisponibles[indexDeConversaciones].reUsar);
        }
    }

    public void Conversar()
    {
        if(indexDeConversaciones <= conversacionesDisponibles.Count - 1)
        {
            if (conversacionesDisponibles[indexDeConversaciones].desbloqueada)
            {
                if (conversacionesDisponibles[indexDeConversaciones].finalizado)
                {
                    if (ActualizarConversacion())
                    {
                        S_DialogoManager.instance.MostrarUI(true);
                        S_DialogoManager.instance.SetConversacion(conversacionesDisponibles[indexDeConversaciones], this);
                    }
                    S_DialogoManager.instance.SetConversacion(conversacionesDisponibles[indexDeConversaciones],this);
                    return;
                }
                S_DialogoManager.instance.MostrarUI(true);
                S_DialogoManager.instance.SetConversacion(conversacionesDisponibles[indexDeConversaciones], this);
            }
            else
            {
                Debug.LogWarning("Conversacion Bloqueada");
                S_DialogoManager.instance.MostrarUI(false);
            }
        }
        else
        {
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
            return true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            S_DialogoManager.instance.MostrarUI(false);
        }
    }

}
