using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEOAquaAttack : MonoBehaviour
{
    public Sprite AEO_AquaAttack;
    GameObject enemigoGolpeado;

    [SerializeField] float rapidezExpansion;
    [SerializeField] float tamañoMáximo;

    float tamaño = 0;

    private void OnEnable()
    {
        Destroy(GetComponent<Animator>());
        Destroy(GetComponent<ActivateElementOnCollision>());
        Destroy(GetComponent<ProjectileCollition>());
        Destroy(GetComponent<MueveProyectil>());
        Destroy(GetComponent<ProjectileMakeDamage>());
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
        transform.localScale = new Vector2(0f, 0f);
        GetComponent<SpriteRenderer>().sprite = AEO_AquaAttack;
    }

    void Update()
    {
        tamaño += rapidezExpansion * Time.deltaTime;
        transform.localScale = new Vector3(tamaño, tamaño, 0f);

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
