using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class S_DialogoUI : MonoBehaviour
{

    public Conversacion conversacion; //Conversacion actual mostrada
    [SerializeField]
    private float textSpeed = 10;

    [SerializeField]
    private GameObject convContainer;

    [SerializeField]
    private Image speakIm;
    [SerializeField]
    private TextMeshProUGUI nombre;
    [SerializeField]
    private TextMeshProUGUI convText;

    [SerializeField]
    private Button continuarBoton;
    [SerializeField]
    private Button anteriorBoton;

    private AudioSource audioSource;

    public int localIn = 0; // Recorre cada dialogo de la conversacion


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        convContainer.SetActive(true);





    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            ActualizarTextos(1);
        }
        
    }

    public void ActualizarTextos(int comportamiento)
    {
        convContainer.SetActive(true);


        Debug.Log("Nuevos Textos");
        switch(comportamiento)
        {
            //Retroceder el texto
            case -1:
                convText.text = "";
                if (localIn > 0)
                {
                    print("Dialogo anterior");
                    localIn--;

                    nombre.text = conversacion.dialogos[localIn].personaje.nombre;
                    StopAllCoroutines();
                    StartCoroutine(EscribirTexto());
                    if (conversacion.dialogos[localIn].personaje != null)
                        speakIm.sprite = conversacion.dialogos[localIn].personaje.imagen;

                    if(conversacion.dialogos[localIn].sonido!= null)
                    {
                        audioSource.Stop();
                        var audio = conversacion.dialogos[localIn].sonido;
                        audioSource.PlayOneShot(audio);
                    }
                    anteriorBoton.gameObject.SetActive(localIn > 0);

                }

                S_DialogoManager.speakerActual.dialLocalIn = localIn;

                break;

            //No avanzar el texto

            case 0:
                convText.text = "";
                print("Dialogo actualizado");

                nombre.text = conversacion.dialogos[localIn].personaje.nombre;
                StopAllCoroutines();
                StartCoroutine(EscribirTexto());
       

                if (conversacion.dialogos[localIn].personaje != null)
                    speakIm.sprite = conversacion.dialogos[localIn].personaje.imagen;

                if (conversacion.dialogos[localIn].sonido != null)
                {
                    audioSource.Stop();
                    var audio = conversacion.dialogos[localIn].sonido;
                    audioSource.PlayOneShot(audio);


                    // Si quieres asegurarte de que el sonido no se repita, puedes establecerlo a null
                    audio = null;
                }
                anteriorBoton.gameObject.SetActive(localIn > 0);

                if(localIn >= conversacion.dialogos.Length -1)
                {
                    continuarBoton.GetComponentInChildren<TextMeshProUGUI>().text = "Finalizar";
                }
                else
                {
                    continuarBoton.GetComponentInChildren<TextMeshProUGUI>().text = "Continuar";
                }

                break;

            case 1:
                convText.text = "";
                if (localIn < conversacion.dialogos.Length - 1)
                {
                    print("Dialogo Siguiente");
                    localIn++;
                    nombre.text = conversacion.dialogos[localIn].personaje.nombre;
                    StopAllCoroutines();
                    StartCoroutine(EscribirTexto());
                    if (conversacion.dialogos[localIn].personaje != null)
                        speakIm.sprite = conversacion.dialogos[localIn].personaje.imagen;

                    if (conversacion.dialogos[localIn].sonido != null)
                    {
                        audioSource.Stop();
                        var audio = conversacion.dialogos[localIn].sonido;
                        audioSource.PlayOneShot(audio);
                    }
                    anteriorBoton.gameObject.SetActive(localIn > 0);
                    if (localIn >= conversacion.dialogos.Length - 1)
                    {
                        continuarBoton.GetComponentInChildren<TextMeshProUGUI>().text = "Finalizar";
                    }
                    else
                    {
                        continuarBoton.GetComponentInChildren<TextMeshProUGUI>().text = "Continuar";
                    }

                }
                else
                {
                    print("Dialogo terminado");
                    localIn = 0;
                    S_DialogoManager.speakerActual.dialLocalIn = 0;
                    conversacion.finalizado = true;
                    if(S_DialogoManager.speakerActual.indexDeConversaciones < S_DialogoManager.speakerActual.conversacionesDisponibles.Count - 1)
                        S_DialogoManager.speakerActual.indexDeConversaciones += 1;

                    if (conversacion.Evento)
                        LevelManager.instance.newEvent(conversacion.EventCode);

                    S_DialogoManager.instance.MostrarUI(false);
                    
                    return;
                }
                S_DialogoManager.speakerActual.dialLocalIn = localIn;
                break;

            default:
                Debug.LogWarning("Valor no admitido " + comportamiento + " solo puede ser -1, 0 o 1");
                break;


        }
    }

    IEnumerator EscribirTexto()
    {
        string temp = conversacion.dialogos[localIn].dialogo;
        convText.text = "";
        //convText.maxVisibleCharacters = 0;
        Debug.Log("Nuevo Dialogo: " + conversacion.dialogos[localIn].dialogo);
        convText.richText = true;
        
        foreach(char letra in temp.ToCharArray())
        {
            convText.text += letra;
            yield return new WaitForSeconds(1f / textSpeed);
                    
        }
    }
}
