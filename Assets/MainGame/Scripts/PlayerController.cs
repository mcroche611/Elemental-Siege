using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declarar las variables
    public float velocity;
    Rigidbody2D rb;


    private void Awake()
    {
        GameManager.GetInstance().SetPlayerTransform(gameObject.transform);
    }

    void Start()
    {
        //Cacheamos el componente Rigidbody
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //Input de movimiento de cuatro direccones y movimiento en diagonal
        Vector2 vel = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        //Velocidad de Movimiento
        rb.velocity = new Vector2(vel.x * velocity, vel.y * velocity);
    }
}
