using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruyeProjectil : MonoBehaviour
{
    Vector2 posicionInicial;
    [SerializeField] float distanciaMaxima;

    private void OnTriggerEnter2D(Collider2D other) { Destroy(this.gameObject); }          

    private void Start()
    {
        posicionInicial = transform.position;
    }

    private void Update()
    {       
        if (DistanciaRecorrida() > distanciaMaxima)
            Destroy(this.gameObject);
    }

    private float DistanciaRecorrida()
    {
        Vector2 posicionActual = transform.position;
        //devuelvo la hipotenusa para saber la distancia recorrida
        return (posicionActual.y - posicionInicial.y) / Mathf.Sin(Mathf.Atan2(posicionActual.y - posicionInicial.y, posicionActual.x - posicionInicial.x));
    }
}
