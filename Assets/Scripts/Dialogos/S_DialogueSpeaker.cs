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


    }

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

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
