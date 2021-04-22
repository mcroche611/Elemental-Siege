using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagoEncerrado : MonoBehaviour
{
    [SerializeField] string elemento;
    [SerializeField] float cantidad;

    public Transform puerta;
    Rigidbody2D rb;

    bool moverse = false;
    bool haHablado = false;

    private void Start()
    {
        if (!GameManager.GetInstance().EscenaCompleta()) Destroy(this.gameObject);
    }

    private void Update()
    {
        if (moverse)
            rb.velocity = puerta.position.normalized * 5;
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() && !haHablado)
        {
            GameManager.GetInstance().CompletarEscena();
            GameManager.GetInstance().AumentarBono(elemento, cantidad);
            rb = GetComponent<Rigidbody2D>();
            moverse = true;          
            haHablado = true;
        }
    }
}
