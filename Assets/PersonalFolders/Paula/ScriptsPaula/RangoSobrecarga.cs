using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoSobrecarga : MonoBehaviour
{
    
    
    [SerializeField]
    int extension;
    [SerializeField]
    float empuje;
    int maxScale = 5;
    float scale;
    void Start()
    {
        transform.localScale = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        scale += extension * Time.deltaTime;
        transform.localScale = new Vector3(scale, scale, 0f);

        if (scale > maxScale)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rbEnemy = collision.GetComponent<Rigidbody2D>();
        Vector2 direction = (rbEnemy.transform.position - transform.position).normalized;
        rbEnemy.AddForce(direction * empuje, ForceMode2D.Impulse);
    }
}
