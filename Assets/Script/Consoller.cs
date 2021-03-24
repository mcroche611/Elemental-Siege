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
        //Declarar los movimientos horizontales y verticales
        deltaX = Input.GetAxis("Horizontal") * velocity;
        deltaY = Input.GetAxis("Vertical") * velocity;
        //Cacheamos el componente Rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        //Obtenemos el movimiento en vector
        vector = new Vector2(deltaX, deltaY);
        //Movimiento diagonal
        if(deltaX!=0 && deltaY != 0)
        {
            vector = new Vector2(deltaX / 2, deltaY / 2);
=======
<<<<<<< HEAD:Assets/Script/Consoller.cs
        
        //Obtenemos el input de la direccion y lo multiplicamos por la velocidad
        deltaX = Input.GetAxis("Horizontal") * velocity;
        deltaY = Input.GetAxis("Vertical") * velocity;
        //Movimiento diagonal
        if(deltaX!=0 && deltaY != 0)
        {
            vector = new Vector2(deltaX / 2, deltaY / 2);
            //transform.Translate(deltaX / 2, deltaY / 2, 0);
=======
        //Obtenemos el input de la direccion y lo multiplicamos por la velocidad
        vector = new Vector2(Input.GetAxis("Horizontal") * velocity, Input.GetAxis("Vertical") * velocity);
        //Movimiento diagonal
        if(deltaX!=0 && deltaY != 0)
        {
            vector = new Vector2(Input.GetAxis("Horizontal") * velocity / 2, Input.GetAxis("Vertical") * velocity / 2);
>>>>>>> a4910c840857d1f35b9d81f2a8af5604d8633f3d:Assets/Menggen/Script/Consoller.cs
>>>>>>> db9047a8fa050a1d54c3798e5174d5738d715094
        }
    }
    //Movemos al jugador en el fixedUpdate ya que se trata de un movimiento físico
    private void FixedUpdate()
    {
        rb.velocity = vector;
    }
}
