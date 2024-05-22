using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Per_Movimiento : MonoBehaviour
{

    [SerializeField] private float velocidad;

    private Rigidbody2D rig;

    private Animator anim;

    public SpriteRenderer imgSprite;

    public int vidaMaxPersonaje = 6;

    public static bool interactuando = false;

    public bool quemado = false;





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
            if (GameManager.Instance.vidas < vidaMaxPersonaje)
            {
                GameManager.Instance.vidas += cantidad;
                if(GameManager.Instance.vidas > vidaMaxPersonaje)
                {
                    GameManager.Instance.vidas = vidaMaxPersonaje;
                }
                LevelManager.instance.managerUI.ActualizarVidaUI(GameManager.Instance.vidas);
            }
        }
        else
        {
            if(GameManager.Instance.vidas > 0) {
                GameManager.Instance.vidas -= cantidad;
                LevelManager.instance.managerUI.ActualizarVidaUI(GameManager.Instance.vidas);
            }
        }
    }

    public void DanoJugador(int cantidad)
    {
        //Debug.Log(recuperacion+";"+cantidad+"");
        StartCoroutine(damage());
            if (GameManager.Instance.vidas > 0)
            {
            GameManager.Instance.vidas -= cantidad;
                LevelManager.instance.managerUI.ActualizarVidaUI(GameManager.Instance.vidas);
            }

        if (GameManager.Instance.vidas <= 0)
        {
            GameManager.Instance.GameOver();
        }
        Debug.Log("Player life change: " + GameManager.Instance.vidas);
    }

    IEnumerator damage()
    {
        imgSprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        imgSprite.color = Color.white;
    }

}
