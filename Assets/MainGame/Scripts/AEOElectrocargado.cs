using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEOElectrocargado : MonoBehaviour
{
    [SerializeField] float diametro;

    void Start()
    {
        transform.localScale = new Vector2(diametro, diametro);
        Destroy(gameObject, Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StateManager stateManager = collision.GetComponent<StateManager>();

        if (stateManager != null && collision.GetComponent<Mojado>().enabled)
        {
            stateManager.NewElement("Electricidad_Electrocutado");
        }
    }

}
