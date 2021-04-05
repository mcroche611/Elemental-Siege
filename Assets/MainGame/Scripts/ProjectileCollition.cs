﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollition : MonoBehaviour
{
    public GameObject AEOAquaAttack;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        if (GetComponent<ActivateElementOnCollision>().Elemento() == "Agua")
            Instantiate<GameObject>(AEOAquaAttack, other.transform.position, AEOAquaAttack.transform.rotation);
    }

    Vector2 posicionInicial;
    [SerializeField] float distanciaMaxima;

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
