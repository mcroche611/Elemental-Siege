using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    string orientacion;

    private void Start()
    {
        orientacion = gameObject.name.Split(' ')[1];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>())
            GameManager.GetInstance().Puerta(orientacion);
    }
}
