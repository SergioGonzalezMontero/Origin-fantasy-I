using UnityEngine;

public class MecanicaPI : MonoBehaviour
{
    public float speed = 10f; // Velocidad de movimiento del personaje
    public LayerMask obstacleMask; // Capa que representa las paredes

    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.zero; // Direcci�n actual de movimiento
    private bool canMove = true; // Indica si el personaje puede moverse o no
    private Vector2 lastMoveDirection; // �ltima direcci�n de movimiento

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Si el personaje puede moverse y se presiona una tecla de direcci�n
        if (canMove && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                        Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            // Obtener la direcci�n de movimiento basada en la tecla presionada
            moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            // Normalizar la direcci�n para mantener la misma velocidad en diagonal
            moveDirection.Normalize();

            // Guardar la �ltima direcci�n de movimiento
            

            // Mover al personaje en la direcci�n especificada
            rb.velocity = moveDirection * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el personaje colisiona con una pared (la capa de la colisi�n est� en obstacleMask)
        if (obstacleMask == (obstacleMask | (1 << collision.gameObject.layer)))
        {
            // Detener el movimiento del personaje
            rb.velocity = Vector2.zero;

            // Permitir al usuario seleccionar una nueva direcci�n de movimiento
            canMove = true;
        }
    }

    void OnDisable()
    {
        lastMoveDirection = moveDirection;
        moveDirection = Vector2.zero;
        rb.velocity = Vector2.zero;
    }

    void OnEnable()
    {
        moveDirection = -lastMoveDirection;
        rb.velocity = moveDirection * speed;
    }
}

