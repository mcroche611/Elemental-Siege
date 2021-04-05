using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulla: MonoBehaviour
{
    public float velocidad;
    public Transform pointA;
    public Transform pointB;
    public float alcance;
    public float tiempoDeEspera;

    void Update()
    {
        Vector2 movArriba = new Vector2(0f, velocidad);
        Vector2 movAbajo = new Vector2(0f, -velocidad);


        //Si la distancia del jugador al punto es mayor o igual al alcnce, volver al otro punto
        //Para calcular la distancia entre dos puntos usamos Vector2.Distance


        transform.Translate(movArriba * Time.deltaTime);
        if (Vector2.Distance(transform.position, pointA.transform.position) <= alcance)
        {
            //Pedimos que espere una determinada cantidad de segundos editable desde el editor
            //if (tiempoDeEspera >= Time.deltaTime)
            //{
            transform.up = Vector2.down;
            transform.Translate(movAbajo * Time.deltaTime);
            //}

        }
        if (Vector2.Distance(transform.position, pointB.transform.position) <= alcance)
        {
            //Pedimos que espere una determinada cantidad de segundos editable desde el editor
            //if (tiempoDeEspera >= Time.deltaTime)
            {
                transform.up = Vector2.up;
                transform.Translate(movArriba * Time.deltaTime);
            }

        }



    }
}
