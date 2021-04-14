using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaMoveAttack : MonoBehaviour
{
    [SerializeField]
    float speed = 10;
    [SerializeField]
    float arrowAttack = 15;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            collision.GetComponent<Health>().ReceiveDamage(arrowAttack);
        }
    }
}
