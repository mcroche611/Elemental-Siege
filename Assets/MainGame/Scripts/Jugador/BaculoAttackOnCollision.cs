using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaculoAttackOnCollision : MonoBehaviour
{
    [SerializeField] float knock; //no es una velocidad realmente, es una fuerza en sí creo
    float playerAttack;
    //Enemy enemy;

    private void Start()
    {
        playerAttack = GameManager.GetInstance().Stat("");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>() != null)
        {
            //Knockback
            Rigidbody2D rbEnemy = collision.GetComponent<Rigidbody2D>(); 
            Vector2 direction = (rbEnemy.transform.position - transform.position).normalized; 
            rbEnemy.AddForce(direction * knock, ForceMode2D.Impulse);
            //Aturdimiento
            collision.GetComponent<EnemyMovement>().enabled = false;
            //QuitarVida
            collision.GetComponent<EnemyHealth>().QuitarVida(playerAttack);
        }
    }
}
