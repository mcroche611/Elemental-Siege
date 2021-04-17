using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEOAquaAttack : MonoBehaviour
{
    GameObject enemigoGolpeado;

    [SerializeField] float rapidezExpansion;
    [SerializeField] float tamañoMáximo;

    float tamaño = 0;

    private void Start()
    {
        transform.localScale = new Vector2(0f, 0f);
    }

    void Update()
    {
        tamaño += rapidezExpansion * Time.deltaTime;
        transform.localScale = new Vector2(tamaño, tamaño);

        if (tamaño > tamañoMáximo)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        StateManager stateManager = collision.GetComponent<StateManager>();

        if (stateManager != null && collision.gameObject != enemigoGolpeado)
        {

            stateManager.NewElement("Agua_Mojado");
        }
    }

    public void EnemigoGolpeado(GameObject collision)
    {
        enemigoGolpeado = collision;
    }
}
