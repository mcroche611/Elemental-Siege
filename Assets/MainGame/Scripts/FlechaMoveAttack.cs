using UnityEngine;

public class FlechaMoveAttack : MonoBehaviour
{
    [SerializeField]
    float speed = 10;
    [SerializeField]
    float arrowAttack = 15;

    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //cacheamos el rb
        rb.velocity = transform.up * speed; //hacemos que la flecha se mueva al instanciarse

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            collision.GetComponent<Health>().ReceiveDamage(arrowAttack);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
