using UnityEngine;

public class MecanicaPI : MonoBehaviour
{
    public float speed = 10f; // Velocidad de movimiento del personaje
    public LayerMask obstacleMask; // Capa que representa las paredes

    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.zero; // Dirección actual de movimiento
    private bool canMove = true; // Indica si el personaje puede moverse o no

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Si el personaje puede moverse y se presiona una tecla de dirección
        if (canMove && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) ||
                        Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)))
        {
            // Obtener la dirección de movimiento basada en la tecla presionada
            moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            // Normalizar la dirección para mantener la misma velocidad en diagonal
            moveDirection.Normalize();

            // Mover al personaje en la dirección especificada
            rb.velocity = moveDirection * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Si el personaje colisiona con una pared
        if (collision.gameObject.layer == obstacleMask)
        {
            // Detener el movimiento del personaje
            rb.velocity = Vector2.zero;

            // Permitir al usuario seleccionar una nueva dirección de movimiento
            canMove = true;
        }
    }
}
