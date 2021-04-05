using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnCollision : MonoBehaviour
{
    [SerializeField]
    int damage;

    [SerializeField]
    int coolDown;

    public float knock = 1f;
    bool attackEnabled = true;
    Rigidbody2D rbPlayer;

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
}
