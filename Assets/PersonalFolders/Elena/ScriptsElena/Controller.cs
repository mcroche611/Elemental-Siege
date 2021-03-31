using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    //velocidad del jugador
    public float velocityScale;
    //RigidBody2D del jugador
    private Rigidbody2D rb2d;
    //vector para el movimiento
    private Vector2 movement;
    public void Start()
    {
        //se accede al componente y se guarda en la variable
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //se declara el input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        //rotar el sprite según el movimiento
        
        //hacia la izquierda
        if (movement.x < -0.1f)
        {
            transform.up = Vector2.left;
        }
        //hacia la derecha
        else if (movement.x > 0.1f)
        {
            transform.up = Vector2.right;
        }
    }
    void FixedUpdate()
    {
        //movimiento físico
        rb2d.MovePosition(rb2d.position + movement * velocityScale * Time.fixedDeltaTime);
    }
}
