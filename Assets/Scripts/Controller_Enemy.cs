using UnityEngine;

public class Controller_Enemy : MonoBehaviour
{
    public static float enemyVelocity;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(new Vector3(-enemyVelocity, 0, 0), ForceMode.Force);
        OutOfBounds();
    }

    public void OutOfBounds() // Destruye el objeto enemigo si la posicion en x es -15
    {
        if (this.transform.position.x <= -15)
        {
            Destroy(this.gameObject);
        }
    }
}
