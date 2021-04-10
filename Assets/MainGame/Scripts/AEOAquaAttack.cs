using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEOAquaAttack : MonoBehaviour
{
    [SerializeField] float rapidezExpansion;
    [SerializeField] float tamañoMáximo;

    float tamaño = 0;

    void Start()
    {
        transform.localScale = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        tamaño += rapidezExpansion * Time.deltaTime;
        transform.localScale = new Vector3(tamaño, tamaño, 0f);

        if (tamaño > tamañoMáximo)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D info)
    {
        StateManager stateManager = info.GetComponent<StateManager>();

        if (stateManager != null)
        {
            stateManager.NewElement("Agua_Mojado");
        }
    }
}
