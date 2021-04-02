using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float detectRange;

    [SerializeField]
    float speed;

    float distToPlayer;
    Vector2 vel;
    int horizontal, vertical;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < detectRange)
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            horizontal = 1;
        }
        else if (transform.position.x > player.position.x)
        {
            horizontal = -1;
        }

        if (transform.position.y < player.position.y)
        {
            vertical = 1;
        }
        else if (transform.position.y > player.position.y)
        {
            vertical = -1;
        }

        vel = new Vector2(horizontal, vertical).normalized;
       
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(vel.x * speed, vel.y * speed);
    }
}
