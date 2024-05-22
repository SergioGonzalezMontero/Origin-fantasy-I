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
    private GameObject pregContainer;

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
        pregContainer.SetActive(false);

        continuarBoton.gameObject.SetActive(true);
        anteriorBoton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      //  if(Input.GetKeyDown(KeyCode.Q))
      //  {
      //      ActualizarTextos(1);
      //  }
    }

    public void ActualizarTextos(int comportamiento)
    {
        convContainer.SetActive(true);
        pregContainer.SetActive(false);

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
                speakIm.sprite = conversacion.dialogos[localIn].personaje.imagen;

                if (conversacion.dialogos[localIn].sonido != null)
                {
                    audioSource.Stop();
                    var audio = conversacion.dialogos[localIn].sonido;
                    audioSource.PlayOneShot(audio);
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

                    if (conversacion.pregunta != null)
                    {
                        convContainer.SetActive(false);
                        pregContainer.SetActive(true);
                        var preg = conversacion.pregunta;
                        S_DialogoManager.instance.controladorPreguntas.ActivarBotones(preg.opciones.Length, preg.pregunta, preg.opciones);

                        return;
                    }
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
            Debug.Log("New Char");
            convText.text += letra;
            yield return new WaitForSeconds(1f / textSpeed);
                    
        }
    }
}
