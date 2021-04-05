using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateElementOnCollision : MonoBehaviour
{
    [SerializeField] string element;

    void OnCollisionEnter2D(Collision2D collision)
    {       
        GameObject other = collision.gameObject;
                
        if (other.GetComponent<Enemy>() != null)
        {
            other.GetComponent<StateManager>().NewElement(element);
        }
    }

    public string Elemento()
    {
        return element.Split('_')[0];
    }
}
