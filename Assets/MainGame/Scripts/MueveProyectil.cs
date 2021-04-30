using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MueveProyectil : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }
}
