using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baculo : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 0.5f); //destruirlo despues de crearlo
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            Destroy(GetComponent<BoxCollider2D>());
        }
    }
}
