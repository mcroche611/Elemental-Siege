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
            Rigidbody2D rbPlayer = collision.GetComponent<Rigidbody2D>();
            Vector2 direction = (rbPlayer.transform.position - transform.position).normalized;
            rbPlayer.AddForce(direction * knock, ForceMode2D.Impulse);
            //Aturdimiento
            collision.GetComponent<PlayerController>().enabled = false;
            //QuitarVida
            collision.GetComponent<Health>().ReceiveDamage(attackDamage);
        }
    }
}

