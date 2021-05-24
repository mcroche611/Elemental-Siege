using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
            if (rb.velocity.x > 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
            
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() && !haHablado)
        {
            LevelManager.GetInstance().CompletarHabitacion();
            GameManager.GetInstance().AumentarBono(elemento, cantidad);
            SoundManager.GetInstance().powerUpSound();
            rb = GetComponent<Rigidbody2D>();
            moverse = true;          
            haHablado = true;
            sale = true;
        }
    }
}
