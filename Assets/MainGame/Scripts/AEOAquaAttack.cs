using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEOAquaAttack : MonoBehaviour
{
    [SerializeField] float rapidezExpansion = 0.5f;
    [SerializeField] float tamañoMáximo = 5f;
    float tamaño = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        tamaño += rapidezExpansion * Time.deltaTime;
        transform.localScale = new Vector3(tamaño, tamaño, 0f);

        if (tamaño > tamañoMáximo)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D info)
    {
        GameObject other = info.gameObject;

        if (other.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.GetComponent<StateManager>().NewElement("Agua_Mojado");
        }
    }
}
