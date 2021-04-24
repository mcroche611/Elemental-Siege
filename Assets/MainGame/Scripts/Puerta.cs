using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    string orientacion;
    bool puedeEntrar = false;

    private void Start()
    {
        orientacion = gameObject.name.Split(' ')[1];
        Invoke("PuedeEntrar", 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() && puedeEntrar)
            GameManager.GetInstance().Puerta(orientacion);
        else if (collision.GetComponent<MagoEncerrado>())
            Destroy(collision.gameObject);
    }

    void PuedeEntrar()
    {
        puedeEntrar = true;
    }
}
