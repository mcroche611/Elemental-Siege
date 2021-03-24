using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knock = 0.0002f; //no es una velocidad realmente, es una fuerza en sí creo

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Enemy>() != null) //miramos a ver si se choca con la espada, lo unico que tiene el script
        {
            Debug.Log("colision espada enemigo");
            Rigidbody2D rbEnemy = col.GetComponent<Rigidbody2D>(); //accedemos al rb enemigo porque es lo que colisiona con la espada
            Vector2 direction = (rbEnemy.transform.position - transform.position).normalized; //al restar dos puntos nos da su vector de dirección
            rbEnemy.AddForce(direction * knock, ForceMode2D.Impulse);  //usando la masa del objeto genera una fuerza



            //rbEnemy.velocity = direction * knock; Así no funciona tampoco
            //knock = -knock;

            //el problema es que manda al enemigo sin pausa a dios sabe dónde
            //aunque los enemigos se supone que van a estar persiguiéndote, eso de por sí generaría otra fuerza mayor
            //Aparte, cómo solucionar que el rigidbody del enemigo y el jugador colisionen? haciendo que las layers no colisionen entre si? pero molaria que tampoco pudieras pasar entre enemigos
            //o hacer un bucle con un contador de segundos y que el knockback solo ocurriera durante un par. creo que no funciona así, la fuerza ya está aplicada.

        }





    }
}
