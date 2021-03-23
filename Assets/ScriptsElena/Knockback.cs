using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    Vector3 mouseDir = new Vector3();
    int velocidadKnock = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = new Vector3();
        
        mousePosition = Input.mousePosition;
        mouseDir = (mousePosition).normalized;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Enemy>() != null) //miramos a ver si se choca con el enemigo, el unico que tiene el script
        {
            Rigidbody2D rbEnemy = col.GetComponent<Rigidbody2D>(); //accedemos al rb enemigo porque es lo que colisiona con la espada
            rbEnemy.velocity = mouseDir * velocidadKnock;

        }





    }
}
