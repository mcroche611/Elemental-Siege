using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declarar las variables
    public float velocity;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //Cacheamos el componente Rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vel = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        rb.velocity = new Vector2(vel.x * velocity, vel.y * velocity);
    }
}
