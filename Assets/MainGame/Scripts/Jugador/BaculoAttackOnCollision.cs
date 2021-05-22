using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaculoAttackOnCollision : MonoBehaviour
{
    [SerializeField] float knock;
    [SerializeField] float tiempoAturdimiento;

    float playerAttack;
    BoxCollider2D boxCollider;


    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        playerAttack = GameManager.GetInstance().Stat("");
    }

    private void OnEnable()
    {
        boxCollider.enabled = true;
        Invoke("DesactivarEspada", 0.1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth helth = collision.GetComponent<EnemyHealth>();
        EnemyMovement enemyMovement = collision.GetComponent<EnemyMovement>();

        if (helth != null)
        {
            //Knockback
            if (enemyMovement != null)
            {
                collision.GetComponent<EnemyMovement>().Knockback(tiempoAturdimiento);
                Rigidbody2D rbEnemy = collision.GetComponent<Rigidbody2D>();
                Vector2 direction = (rbEnemy.transform.position - transform.position).normalized;
                rbEnemy.AddForce(direction * knock, ForceMode2D.Impulse);
            }         
            //Producir sonido de ataque fisico
            SoundManager.GetInstance().physicAttackSound();
            //QuitarVida
            helth.QuitarVida(playerAttack);
        }
    }



    private void DesactivarEspada()
    {
        boxCollider.enabled = false;
    }


}
