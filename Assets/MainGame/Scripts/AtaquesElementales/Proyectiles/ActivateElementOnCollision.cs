using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateElementOnCollision : MonoBehaviour
{
    [SerializeField] string element;

    public GameObject AOEAquaAttack;

    void OnTriggerEnter2D(Collider2D collision)
    {       
        StateManager stateManager = collision.GetComponent<StateManager>();
                
        if (stateManager != null)
        {
            if (Elemento() == "Agua")
            {
                GameObject _AOEAquaAttack = (GameObject)Instantiate(AOEAquaAttack, transform.position, transform.rotation);
                _AOEAquaAttack.GetComponent<AEOAquaAttack>().EnemigoGolpeado(collision.gameObject);
            }
            else collision.GetComponent<ElementalReactions>().RotacionBola(GetComponent<Rigidbody2D>().velocity);

            Escudo escudo = collision.GetComponent<Escudo>();

            if (escudo == null)
                stateManager.NewElement(element);
            else if (!escudo.enabled)
                stateManager.NewElement(element);
        }
    }



    public string Elemento()
    {
        return element.Split('_')[0];
    }
}
