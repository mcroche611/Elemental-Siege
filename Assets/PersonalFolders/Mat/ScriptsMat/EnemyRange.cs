using System;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    //add Raycast within range???

    [SerializeField]
    float detectRange;

    [SerializeField]
    float attackRange;

    [SerializeField]
    float speed;

    float distToPlayer;
    Vector2 vel;
    int unit = 1;

    Transform player;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameManager.GetInstance().GetPlayerTransform();

        if (player != null)
            Debug.Log("Player transform correct");
        else
            Debug.Log("Player transform not found");
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < detectRange)
        {
            ChasePlayer();
        }

        if (distToPlayer < attackRange) //or OnCollisionEnter2D
        {
            AttackPlayer();
        }
    }

    private void AttackPlayer()
    {
        throw new NotImplementedException();
    }

    void ChasePlayer()
    {
        int horizontal = 0, vertical = 0;

        if (Mathf.Abs(transform.position.x - player.position.x) < unit)
        {
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
