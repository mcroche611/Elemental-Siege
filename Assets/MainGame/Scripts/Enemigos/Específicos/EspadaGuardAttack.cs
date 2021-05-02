using UnityEngine;

public class EspadaGuardAttack : MonoBehaviour
{
    [SerializeField] 
    float knock = 2f;

    [SerializeField]
    float tiempoAturdimiento = 1f;

    [SerializeField]
    float attackDamage = 15f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (collision.GetComponent<Mana>() != null)
        {
            //Knockback        
            player.Knockback(tiempoAturdimiento);
            Rigidbody2D rbPlayer = player.GetComponent<Rigidbody2D>();
            Vector2 direction = (rbPlayer.transform.position - transform.position).normalized;
            rbPlayer.AddForce(direction * knock, ForceMode2D.Impulse);
            //QuitarVida
            collision.GetComponent<Health>().ReceiveDamage(attackDamage);
        }
    }
}

