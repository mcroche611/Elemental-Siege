using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charco : MonoBehaviour
{
    [SerializeField] float tiempoParaMojar;

    bool puedeMojarse = false;
    bool pisaCharco = false;

    LayerMask col;
    Mojado mojado;
    Electrocutado electrocutado;
    StateManager stateManager;

    private void Awake()
    {
        electrocutado = GetComponentInParent<Electrocutado>();
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
            else
            {
                NoPuedeMojarse();
                if (state != null)
                {
                    if (state == electrocutado)
                        GetComponentInParent<Paralizar>().Paraliza();
                    stateManager.StateTimeOut();                    
                }
            }
        }           
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pisaCharco = false;
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
                    if (state == electrocutado)
                        GetComponentInParent<Paralizar>().Paraliza();
                    stateManager.StateTimeOut();
                }
            }
        }
        else pisaCharco = false;
    }

    public void NoPuedeMojarse()
    {
        CancelInvoke("PuedeMojarse");
        puedeMojarse = false;
        Invoke("PuedeMojarse", tiempoParaMojar);                       
    }

    void PuedeMojarse()
    {
        puedeMojarse = true;
    }

}
