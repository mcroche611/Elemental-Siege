using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackOnCollision : MonoBehaviour
{
    [SerializeField]
    float knock;

    [SerializeField]
    float damage;

    [SerializeField]
    float attackCoolDown;

    [SerializeField]
    float tiempoAturdimiento;

    bool attackEnabled = true;
    [HideInInspector] public bool paralizado = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player.GetComponent<PlayerController>() != null)
        {        
            if (attackEnabled && !paralizado)
            {
                //Knockback        
                player.Knockback(tiempoAturdimiento);
                Rigidbody2D rbPlayer = player.GetComponent<Rigidbody2D>();
                Vector2 direction = (rbPlayer.transform.position - transform.position).normalized;
                rbPlayer.AddForce(direction * knock, ForceMode2D.Impulse);
                //Quitar vida
                collision.gameObject.GetComponent<Health>().ReceiveDamage(damage);
                //Volver a atacar
                attackEnabled = false;
                Invoke("EnableAttack", attackCoolDown);
            }
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            if (attackEnabled && !paralizado)
            {
                //Knockback
                player.Knockback(tiempoAturdimiento);
                Rigidbody2D rbPlayer = player.GetComponent<Rigidbody2D>();
                Vector2 direction = (rbPlayer.transform.position - transform.position).normalized;
                rbPlayer.AddForce(direction * knock, ForceMode2D.Impulse);
                //Quitar vida
                collision.gameObject.GetComponent<Health>().ReceiveDamage(damage);
                //Volver a atacar
                attackEnabled = false;
                Invoke("EnableAttack", attackCoolDown);
            }

        }
    }


    private void EnableAttack()
    {
        attackEnabled = true;
    }


}
