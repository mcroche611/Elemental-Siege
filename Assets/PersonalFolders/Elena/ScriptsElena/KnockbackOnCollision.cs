using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackOnCollision : MonoBehaviour
{
    int velocidadKnock = 2;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Espada>() != null) //miramos a ver si se choca con la espada, lo unico que tiene el script
        {
            Debug.Log("colision espada enemigo");
            Rigidbody2D rbEspada = col.GetComponent<Rigidbody2D>(); //accedemos al rb enemigo porque es lo que colisiona con la espada
            //rbEnemy.velocity = mouseDir * velocidadKnock;
            Vector2 direction = (transform.position - rbEspada.transform.position).normalized; //al restar dos puntos nos da su vector de dirección
            rb = gameObject.GetComponent<Rigidbody2D>();

            rb.AddForce(direction * velocidadKnock, ForceMode2D.Impulse);  //usando la masa del objeto genera una fuerza
            //Debug.Log("colision espada enemigo");

        }





    }
}
