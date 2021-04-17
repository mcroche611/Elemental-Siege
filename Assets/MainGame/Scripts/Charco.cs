using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charco : MonoBehaviour
{
    [SerializeField] float tiempoParaMojar;

    bool puedeMojarse;
    bool pisaCharco = false;

    LayerMask col;
    Mojado mojado;
    StateManager stateManager;

    private void Awake()
    {
        mojado = GetComponentInParent<Mojado>();
        stateManager = GetComponentInParent<StateManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        col = collision.gameObject.layer;

        if (col == LayerMask.NameToLayer("Charcos") && !pisaCharco)
        {
            CancelInvoke("PuedeMojarse");
            MonoBehaviour state = stateManager.Estado() as MonoBehaviour;
            if (state == mojado)
                puedeMojarse = true;
            else if (state == null)
                NoPuedeMojarse();
            else
            {
                NoPuedeMojarse();
                stateManager.StateTimeOut();
            }
        }           
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        col = collision.gameObject.layer;

        if (col == LayerMask.NameToLayer("Charcos"))
        {
            pisaCharco = true;
            if (puedeMojarse)
            {
                MonoBehaviour state = stateManager.Estado() as MonoBehaviour;
                if (state == null || state == mojado)
                    stateManager.NewElement("Agua_Mojado");
                else
                {
                    NoPuedeMojarse();
                    stateManager.StateTimeOut();
                }
            }
        }
        else pisaCharco = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pisaCharco = false;
    }


    public void NoPuedeMojarse()
    {
        if (col == LayerMask.NameToLayer("Charcos"))
        {
            puedeMojarse = false;
            Invoke("PuedeMojarse", tiempoParaMojar);
        }            
    }

    void PuedeMojarse()
    {
        puedeMojarse = true;
    }

}
