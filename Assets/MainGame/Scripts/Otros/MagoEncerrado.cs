using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagoEncerrado : MonoBehaviour
{
    [SerializeField] string elemento;
    [SerializeField] float cantidad;
    [SerializeField] Animator animator;
    public Transform puerta;
    Rigidbody2D rb;

    bool moverse = false;
    bool sale = false; //variable que controla si el mago va a sali de la habitaicón
    bool haHablado = false;

    private void Start()
    {
        if (LevelManager.GetInstance().HabiaEntradoAntes()) 
            Destroy(this.gameObject);
        
    }

    private void Update()
    {
        animator.SetBool("sale", sale);
        if (moverse)
        {
            rb.velocity = puerta.position.normalized * 5;
        }
            
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() && !haHablado)
        {
            LevelManager.GetInstance().CompletarHabitacion();
            GameManager.GetInstance().AumentarBono(elemento, cantidad);
            rb = GetComponent<Rigidbody2D>();
            moverse = true;          
            haHablado = true;
            sale = true;
        }
    }
}
