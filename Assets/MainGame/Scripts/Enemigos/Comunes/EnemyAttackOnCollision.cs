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
    PlayerController pcPlayer;

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Collision");

            rbPlayer = collision.gameObject.GetComponent<Rigidbody2D>();
            // Una vez que colisiona, intenta hacer MakeDamage constante
            InvokeRepeating("MakeDamage", 0f, 0.2f);
        }
    }

    private void MakeDamage()
    {
        // Solo ataca cuando ha pasado el tiempo de cool down
        if (attackEnabled)
        {
            GameManager.GetInstance().EnemyMakeDamage(damage);
            KnockbackPlayer(rbPlayer);
            attackEnabled = false;
            Invoke("EnableAttack", coolDown);
        }
    }

    private void EnableAttack()
    {
        attackEnabled = true;
    }

    private void KnockbackPlayer(Rigidbody2D rbPlayer)
    {
        Vector2 direction = (rbPlayer.transform.position - transform.position).normalized;
        rbPlayer.AddForce(direction * knock, ForceMode2D.Impulse);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CancelInvoke("MakeDamage");
    }
    */

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject player = collision.gameObject;

        if (player.GetComponent<PlayerController>() != null)
        {        
            if (attackEnabled)
            {                                             
                //Knockback
                Rigidbody2D rbPlayer = player.GetComponent<Rigidbody2D>();
                rbPlayer.velocity = new Vector2(0f, 0f);
                Vector2 direction = (rbPlayer.transform.position - transform.position).normalized;
                rbPlayer.AddForce(direction * knock, ForceMode2D.Impulse);
                //Aturdimiento
                pcPlayer = player.GetComponent<PlayerController>();
                pcPlayer.enabled = false;
                //Quitar vida
                player.GetComponent<Health>().ReceiveDamage(damage);
                //Volver a atacar
                attackEnabled = false;
                Invoke("EnableAttack", attackCoolDown);
            }
            
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject player = collision.gameObject;

        if (player.GetComponent<PlayerController>() != null)
        {
            if (attackEnabled)
            {
                //Quitar vida
                player.GetComponent<Health>().ReceiveDamage(damage);
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
