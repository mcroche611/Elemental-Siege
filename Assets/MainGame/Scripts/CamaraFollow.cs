using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollow : MonoBehaviour
{
    //Declarar la intendidad que voy a seguir
    public Transform jugador;
    //Declarar una variable de vector3 para calcular la distancia de la camara con el jugador
    Vector3 distancia;
    // Start is called before the first frame update
    void Start()
    {
        distancia = transform.position - jugador.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = jugador.position + distancia;
    }
}
