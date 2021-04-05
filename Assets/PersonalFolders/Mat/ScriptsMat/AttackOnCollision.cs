using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackOnCollision : MonoBehaviour
{
    [SerializeField]
    int damage;

    [SerializeField]
    int coolDown;

    bool attackEnabled = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            Debug.Log("Collision");

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
            attackEnabled = false;
            Invoke("EnableAttack", coolDown);
        }
    }

    private void EnableAttack()
    {
        attackEnabled = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        CancelInvoke("MakeDamage");
    }
}
