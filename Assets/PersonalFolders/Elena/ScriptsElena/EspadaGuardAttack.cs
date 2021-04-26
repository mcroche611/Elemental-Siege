using UnityEngine;

public class EspadaGuardAttack : MonoBehaviour
{
    [SerializeField] 
    float knock;

    [SerializeField]
    float attackDamage = 15f;
    //Enemy enemy;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Mana>() != null)
        {
            //Knockback
            Rigidbody2D rbEnemy = collision.GetComponent<Rigidbody2D>();
            Vector2 direction = (rbEnemy.transform.position - transform.position).normalized;
            rbEnemy.AddForce(direction * knock, ForceMode2D.Impulse);
            //Aturdimiento
            collision.GetComponent<EnemyMovement>().enabled = false;
            //QuitarVida
            collision.GetComponent<EnemyHealth>().QuitarVida(attackDamage);
        }
    }
}

