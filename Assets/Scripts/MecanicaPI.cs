using UnityEngine;

public class MecanicaPI : MonoBehaviour
{
    public float speed = 10f; // Velocidad de movimiento del personaje

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
        if (rb.velocity == Vector2.zero)
        {
            canMove = true;
        }

        // Si el personaje puede moverse y se presiona una tecla de direcci�n
        if (canMove && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||
                        Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            // Obtener la direcci�n de movimiento basada en la tecla presionada
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Solo permitir movimiento horizontal si no hay entrada vertical
            if (Mathf.Abs(horizontalInput) > Mathf.Abs(verticalInput))
            {
                moveDirection = new Vector2(Mathf.Round(horizontalInput), 0f);
            }
            // Solo permitir movimiento vertical si no hay entrada horizontal
            else
            {
                moveDirection = new Vector2(0f, Mathf.Round(verticalInput));
            }

            // Mover al personaje en la direcci�n especificada
            rb.velocity = moveDirection * speed;

            // No permitir que se cambie la direcci�n del personaje mientras este se est� moviendo
            canMove = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el personaje colisiona con un objeto con el tag "obs"
        if (collision.gameObject.tag == "obs")
        {
            Debug.Log("COLISION CON OBS");
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



