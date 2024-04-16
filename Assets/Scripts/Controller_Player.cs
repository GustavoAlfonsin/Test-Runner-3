using UnityEngine;

public class Controller_Player : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 10;
    private float initialSize;
    private int i = 0;
    private bool floored;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialSize = rb.transform.localScale.y;
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput() //Funcion que detecta cuando el juegador realiza las distintas acciones
    {
        Jump();
        Duck();
    }

    private void Jump()
    {
        if (floored)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    private void Duck()
    {
        if (floored)
        {
            if (Input.GetKey(KeyCode.S))
            {
                if (i == 0) // Si i es igual a 0 divide a la mitad la escala del objeto en y
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, rb.transform.localScale.y / 2, rb.transform.localScale.z);
                    i++;
                }
            }
            else
            {
                if (rb.transform.localScale.y != initialSize) // Si la escala en y no es igual a la escala original recetea el tamaño en y y pone i en 0
                {
                    rb.transform.localScale = new Vector3(rb.transform.localScale.x, initialSize, rb.transform.localScale.z);
                    i = 0;
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.S)) // Si el objeto esta saltando al apretar la tecla s realiza un impulso hacia abajo
            {
                rb.AddForce(new Vector3(0, -jumpForce, 0), ForceMode.Impulse);
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // Si entre en contacto con un enemigo destruye al jugador y activa el gameover
        {
            Destroy(this.gameObject);
            Controller_Hud.gameOver = true;
        }

        if (collision.gameObject.CompareTag("Floor")) // Marca cuando el juegador esta tocando el suelo
        {
            floored = true;
        }
    }

    private void OnCollisionExit(Collision collision) // Marca si el jugador dejo de tocar el suelo
    {
        if (collision.gameObject.CompareTag("Floor")) 
        {
            floored = false;
        }
    }
}
