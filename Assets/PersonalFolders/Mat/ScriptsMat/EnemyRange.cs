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
    int unit = 1;

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
        int horizontal = 0, vertical = 0;

        if (Mathf.Abs(transform.position.x - player.position.x) < unit)
        {
            Debug.Log("Horizontal = 0");
            horizontal = 0;
        }
        else if (transform.position.x < player.position.x)
        {
            horizontal = 1;
        }
        else if (transform.position.x > player.position.x)
        {
            horizontal = -1;
        }

        if (Mathf.Abs(transform.position.y - player.position.y) < unit)
        {
            Debug.Log("Vertical = 0");
            vertical = 0;
        }
        else if (transform.position.y < player.position.y)
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
