using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateElementOnCollision : MonoBehaviour
{
    public string element;

    void OnCollisionEnter(Collision info)
    {       
        GameObject other = info.gameObject;

        other.GetComponent<StateManager>().NewElement(element);

        /*
        if (other.layer != LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("La bola ha chocado contra un NO enemigo");
            return;
        }
        else
        {
            other.GetComponent<StateManager>().NewElement(element);
        } 
        */
    }
}
