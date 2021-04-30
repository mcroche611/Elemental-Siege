using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateElementOnCollision : MonoBehaviour
{
    [SerializeField] string element;

    void OnTriggerEnter2D(Collider2D collision)
    {       
        StateManager stateManager = collision.GetComponent<StateManager>();
                
        if (stateManager != null)
        {
            stateManager.NewElement(element);
        }
    }

    public string Elemento()
    {
        return element.Split('_')[0];
    }
}
