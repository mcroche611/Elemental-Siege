using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaculoAttackOnCollision : MonoBehaviour
{
    [SerializeField] float knock;
    [SerializeField] float tiempoAturdimiento;
    float playerAttack;

    private void Start()
    {
        playerAttack = GameManager.GetInstance().Stat("");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth helth = collision.GetComponent<EnemyHealth>();

        if (helth != null)
        {
            //Knockback
            collision.GetComponent<EnemyMovement>().Knockback(tiempoAturdimiento);
            Rigidbody2D rbEnemy = collision.GetComponent<Rigidbody2D>(); 
            Vector2 direction = (rbEnemy.transform.position - transform.position).normalized; 
            rbEnemy.AddForce(direction * knock, ForceMode2D.Impulse);
            //Producir sonido de ataque fisico
            SoundManager.GetInstance().physicAttackSound();
            //QuitarVida
            helth.QuitarVida(playerAttack);
        }
    }
}
