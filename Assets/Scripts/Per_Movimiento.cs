using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Per_Movimiento : MonoBehaviour
{

    [SerializeField] private float velocidad;

    private Rigidbody2D rig;

    private Animator anim;

    private int vidaPersonaje = 6;
    private int vidaMaxPersonaje = 6;

    public static bool interactuando = false;


    [SerializeField] UIManager uiManager;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        if(!interactuando)
        {
            if(Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("Golpe");
            }
        }
        
    }

    private void FixedUpdate()
    {
        Movimiento();
    }

    private void Movimiento()
    {

        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //rig.velocity = new Vector2(horizontal, vertical) * velocidad;
        //anim.SetFloat("Velocidad", Mathf.Abs(rig.velocity.magnitude));

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Normalizar el movimiento para que el personaje no se mueva más rápido en diagonal
        Vector2 movimiento = new Vector2(horizontal, vertical).normalized;

        // Calcular la velocidad de movimiento multiplicando por la velocidad y el tiempo
        Vector2 velocidadMovimiento = movimiento * velocidad * Time.deltaTime;

        // Aplicar el movimiento al Rigidbody2D
        rig.MovePosition(rig.position + velocidadMovimiento);
        anim.SetFloat("Velocidad", Mathf.Abs(velocidadMovimiento.magnitude));

        if (horizontal >  0)
        {
            anim.SetInteger("Direccion", 1);

        }
        else if (horizontal < 0)
        {
            anim.SetInteger("Direccion", 3);
        }

        if(vertical > 0)
        {
            anim.SetInteger("Direccion", 0);

        }
        else if (vertical < 0)
        {
            anim.SetInteger("Direccion", 2);
        }
    }

    public void ActualizarVida (bool recuperacion, int cantidad)
    {
        //Debug.Log(recuperacion+";"+cantidad+"");

        if (recuperacion)
        {
            if (vidaPersonaje < vidaMaxPersonaje)
            {
                vidaPersonaje += cantidad;
                if(vidaPersonaje > vidaMaxPersonaje)
                {
                    vidaPersonaje = vidaMaxPersonaje;
                }
                uiManager.ActualizarVidaUI(vidaPersonaje);
            }
        }
        else
        {
            if(vidaPersonaje > 0) {
                vidaPersonaje -= cantidad;
                uiManager.ActualizarVidaUI(vidaPersonaje);
            }
        }
    }
}
