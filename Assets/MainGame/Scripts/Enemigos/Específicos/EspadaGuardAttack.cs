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
            //Aturdimiento
            collision.GetComponent<PlayerController>().enabled = false;
            //Knockback
            Rigidbody2D rbPlayer = collision.GetComponent<Rigidbody2D>();
            rbPlayer.velocity = new Vector2(0, 0);
            Vector2 direction = (collision.transform.position - GetComponentInParent<Transform>().GetComponentInParent<Transform>().position).normalized;
            rbPlayer.AddForce(direction * knock, ForceMode2D.Impulse);           
            //QuitarVida
            collision.GetComponent<Health>().ReceiveDamage(attackDamage);
        }
    }
}

