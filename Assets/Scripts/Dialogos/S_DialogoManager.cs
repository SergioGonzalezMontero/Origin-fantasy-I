using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_DialogoManager : MonoBehaviour
{
    
    public static S_DialogoManager instance { get; private set; }
    public static S_DialogueSpeaker speakerActual;
    
    [SerializeField]
    private S_DialogoUI dialUI;

    [SerializeField]
    public GameObject player;

    ////////////////
    public S_ControladorPreguntas controladorPreguntas;
    ////////////////

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        dialUI = FindObjectOfType<S_DialogoUI>();

        /////////////
        controladorPreguntas = FindObjectOfType<S_ControladorPreguntas>();
        /////////////

    }

    void Start()
    {


        MostrarUI(false);


        //para que empiece con conversacion
       // player.GetComponent<S_DialogueSpeaker>().Conversar();
    }

    public void MostrarUI(bool mostrar)
    {
        Debug.Log("UIEntra");
        if(dialUI.gameObject!=null)
            dialUI.gameObject.SetActive(mostrar);
        if (!mostrar)
        {
            dialUI.localIn = 0;
            
            /////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            //AQUI IRIA LA LOGICA PARA INHABILITAR EL MOVIMIENTO
            /////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////


        }
        else
        {
            /////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            //AQUI IRIA LA LOGICA PARA HABILITAR EL MOVIMIENTO
            /////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
            ////////////////////////////////////////////////
        }
    }

    public void SetConversacion(Conversacion conv, S_DialogueSpeaker speaker)
    {
        if(speaker != null)
        {
            Debug.Log("New Speaker");
            speakerActual = speaker;
            dialUI.ActualizarTextos(0);
        }
        else
        {
            dialUI.conversacion = conv;
            dialUI.localIn = 0;
            dialUI.ActualizarTextos(0);
        }
        if(conv.finalizado && !conv.reUsar)
        {
            dialUI.conversacion = conv;
            dialUI.localIn = speakerActual.dialLocalIn;
            dialUI.ActualizarTextos(0);
        }
        else if (!conv.finalizado)
        {
            dialUI.conversacion = conv;
            dialUI.localIn = speakerActual.dialLocalIn;
            dialUI.ActualizarTextos(0);
        }

    }

    //esta se usa para decir que no use un dialogo en cierto momento por ej conseguir al un objeto, hacer otra

    public void CambiarEstadoDeReUsable(Conversacion conv, bool estadoDeseado)
    {
        conv.reUsar = estadoDeseado;
    }

    //funcion a llamar para desbloquear una conversacion
    public void BloqueoYDesbloqueoDeConvrsacion(Conversacion conv, bool desbloquear)
    {
        conv.desbloqueada = desbloquear;
    }


}
