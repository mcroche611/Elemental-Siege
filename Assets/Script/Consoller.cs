using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consoller : MonoBehaviour
{
    //Declarar las variables
    public float velocity;
    float deltaX, deltaY;
    Rigidbody2D rb;
    Vector2 vector;

    // Start is called before the first frame update
    void Start()
    {
        //Cacheamos el componente Rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //Obtenemos el input de la direccion y lo multiplicamos por la velocidad
        deltaX = Input.GetAxis("Horizontal") * velocity;
        deltaY = Input.GetAxis("Vertical") * velocity;
        //Movimiento diagonal
        if(deltaX!=0 && deltaY != 0)
        {
            vector = new Vector2(deltaX / 2, deltaY / 2);
            //transform.Translate(deltaX / 2, deltaY / 2, 0);
        }
    }
    //Movemos al jugador en el fixedUpdate ya que se trata de un movimiento físico
    private void FixedUpdate()
    {
        rb.velocity = vector;
    }
}
