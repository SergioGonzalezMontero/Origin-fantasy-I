using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EfectoAparicion : MonoBehaviour
{
    public float fadeDuration = 1.0f;  // Duración del fade-in en segundos
    public float startDelay = 2.0f;    // Retraso antes de que comience el fade-in
    public bool imagenFinal;
    public Sprite[] notas;

    private Image image;
    private TextMeshProUGUI text;
    private float timer;
    private bool isFadingIn;

    void Start()
    {
        // Obtener el componente de imagen o texto
        image = GetComponent<Image>();
        text = GetComponent<TextMeshProUGUI>();

        // Inicializar el color del componente a transparente
        if (image != null)
        {
            if (imagenFinal)
            {
                image.sprite = notas[GameManager.Instance.nota - 5];
            }
            Color color = image.color;
            color.a = 0f;
            image.color = color;
        }
        if (text != null)
        {
            Color color = text.color;
            color.a = 0f;
            text.color = color;
        }

        timer = 0f;
        isFadingIn = false;



        if (imagenFinal)
        {
            Invoke("VolverEscenaInicio", startDelay + 3);
        }

    }

    void Update()
    {
        if (!isFadingIn)
        {
            // Esperar hasta que pase el tiempo de retraso
            timer += Time.deltaTime;
            if (timer >= startDelay)
            {
                isFadingIn = true;
                timer = 0f;  // Reiniciar el temporizador para el fade-in
            }
        }
        else
        {
            if (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                float alpha = timer / fadeDuration;

                // Actualizar el alfa del color del componente
                if (image != null)
                {
                    Color color = image.color;
                    color.a = Mathf.Clamp01(alpha);
                    image.color = color;
                }
                if (text != null)
                {
                    Color color = text.color;
                    color.a = Mathf.Clamp01(alpha);
                    text.color = color;
                }
                if (text != null)
                {
                    Color color = text.color;
                    color.a = Mathf.Clamp01(alpha);
                    text.color = color;
                }
            }
        }
    }

}
