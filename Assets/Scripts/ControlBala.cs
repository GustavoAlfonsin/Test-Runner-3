using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBala : MonoBehaviour
{
    public static float velocidadBala;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(velocidadBala, 0, 0), ForceMode.Force);
        OutOfBounds();
    }

    public void OutOfBounds() // Destruye el objeto enemigo si la posicion en x es -15
    {
        if (this.transform.position.x >= 15)
        {
            Destroy(this.gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("BigEnemy"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}
