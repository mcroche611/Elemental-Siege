using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollition : MonoBehaviour
{
    public GameObject AOEAquaAttack;

    private void OnTriggerEnter2D(Collider2D other)
    {
        ElementalReactions elementalReactions = other.GetComponent<ElementalReactions>();

        if (elementalReactions != null)
        {
            if (GetComponent<ActivateElementOnCollision>().Elemento() != "Agua")
            {
                other.GetComponent<ElementalReactions>().RotacionBola(GetComponent<Rigidbody2D>().velocity);
            }

            else
            {
                GameObject _AOEAquaAttack = (GameObject) Instantiate(AOEAquaAttack, transform.position, transform.rotation);
                _AOEAquaAttack.GetComponent<AEOAquaAttack>().EnemigoGolpeado(other.gameObject);
            }
        }
        Destroy(this.gameObject);

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
