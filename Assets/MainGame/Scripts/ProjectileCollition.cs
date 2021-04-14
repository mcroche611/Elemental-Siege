using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ElementalReactions elementalReactions = other.GetComponent<ElementalReactions>();

        if (elementalReactions != null)
        {
            if (GetComponent<ActivateElementOnCollision>().Elemento() != "Agua")
            {
                other.GetComponent<ElementalReactions>().RotacionBola(GetComponent<Rigidbody2D>().velocity);
                Destroy(this.gameObject);
            }

            else
            {
                AEOAquaAttack _AEOAquaAttack = GetComponent<AEOAquaAttack>();
                _AEOAquaAttack.EnemigoGolpeado(other.gameObject);
                _AEOAquaAttack.enabled = true;
            }
        }
        else Destroy(this.gameObject);
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
