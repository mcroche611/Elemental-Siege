using System;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    [SerializeField]
    float detectRange;

    [SerializeField]
    float speed;

    Vector2 vel;
    bool attackMode = false;

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
        if (CanSeePlayer(detectRange) && !attackMode)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }

    private bool CanSeePlayer(float detectRange)
    {
        bool val = false;

        int p, m, pm;
        p = 1 << LayerMask.NameToLayer("Player");
        m = 1 << LayerMask.NameToLayer("Muros");
        pm = p | m;

        RaycastHit2D hit = Physics2D.Linecast(transform.position, player.position, pm);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.GetComponent<PlayerController>() != null)
            {
                val = hit.distance <= detectRange;
            }
        }

        Debug.DrawLine(transform.position, player.position, Color.white);

        return val;
    }

    void ChasePlayer()
    {
        Vector2 trayectoria = player.position - transform.position;

        vel = trayectoria.normalized;
    }

    private void StopChasingPlayer()
    {
        vel.x = 0;
        vel.y = 0;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(vel.x * speed, vel.y * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            attackMode = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            attackMode = false;
        }
    }
}
