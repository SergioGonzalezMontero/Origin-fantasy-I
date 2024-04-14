using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Per_Movimiento : MonoBehaviour
{

    [SerializeField] private float velocidad;

    private Rigidbody2D rig;

    private Animator anim;

    private int vidaPersonake = 6;


    [SerializeField] UIManager uiManager;

    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Golpe");
        }
    }

    private void FixedUpdate()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical= Input.GetAxis("Vertical");

        rig.velocity = new Vector2(horizontal, vertical) * velocidad;
        anim.SetFloat("Velocidad", Mathf.Abs(rig.velocity.magnitude));

        if(horizontal >  0)
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
}
