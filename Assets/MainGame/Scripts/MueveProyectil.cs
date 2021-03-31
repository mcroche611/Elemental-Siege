using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MueveProyectil : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }
}
