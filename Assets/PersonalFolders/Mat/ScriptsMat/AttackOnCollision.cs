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
            InvokeRepeating("MakeDamage", 0.5f, coolDown);
        }
    }

    private void MakeDamage()
    {
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
        CancelInvoke();
    }
}
