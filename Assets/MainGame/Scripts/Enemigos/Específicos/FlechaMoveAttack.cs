using UnityEngine;

public class FlechaMoveAttack : MonoBehaviour
{
    [SerializeField]
    float speed = 10;
    [SerializeField]
    float arrowAttack = 15;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed; //hacemos que la flecha se mueva al instanciarse
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();

        if (health != null)
        {
            health.ReceiveDamage(arrowAttack);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
