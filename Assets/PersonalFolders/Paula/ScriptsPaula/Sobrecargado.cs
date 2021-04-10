using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sobrecargado : MonoBehaviour
{
    [SerializeField] 
    float knock;
    [SerializeField]
    GameObject rango;

    
    private void OnEnable()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>(); //??????
        Vector2 direction = (rb.transform.position - transform.position).normalized;
        rb.AddForce(direction * knock, ForceMode2D.Impulse);
        rango.SetActive(true);
       
    }

    private void OnDisable()
    {
        rango.SetActive(false);
    }
}
