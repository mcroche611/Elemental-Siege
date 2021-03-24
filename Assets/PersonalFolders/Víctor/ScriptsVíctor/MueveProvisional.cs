using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MueveProvisional : MonoBehaviour
{
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
    }
}
