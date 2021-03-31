using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateElementOnCollision : MonoBehaviour
{
    [SerializeField] string element;

    void OnCollisionEnter2D(Collision2D info)
    {       
        GameObject other = info.gameObject;
                
        if (other.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.GetComponent<StateManager>().NewElement(element);
        }
    }

    public bool EsAgua()
    {
        return element == "Agua_Mojado";
    }

    public string Elemento()
    {
        return element.Split('_')[0];
    }
}
