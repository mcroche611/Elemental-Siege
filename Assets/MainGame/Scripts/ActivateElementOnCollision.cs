using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateElementOnCollision : MonoBehaviour
{
    [SerializeField] string element;

    void OnTriggerEnter2D(Collider2D collision)
    {       
        GameObject other = collision.gameObject;
                
        if (other.GetComponent<EnemyHealth>() != null)
        {
            other.GetComponent<StateManager>().NewElement(element);
        }
    }

    public string Elemento()
    {
        return element.Split('_')[0];
    }
}
