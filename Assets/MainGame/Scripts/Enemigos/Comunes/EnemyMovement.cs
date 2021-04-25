using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //[SerializeField]
    //float detectRange;

    [SerializeField]
    float speed;

    [SerializeField]
    float tiempoAturdimiento;

    Vector2 vel;
    bool attackMode = false;

    float iniSpeed;
    Transform playerTf;
    Rigidbody2D rb;
    EnemyTrigger trigger;

    void Start()
    {
        iniSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        GetPlayerTransform();
        trigger = GetComponentInChildren<EnemyTrigger>();
    }

    private void GetPlayerTransform()
    {       
        playerTf = GameManager.GetInstance().GetPlayerTransform();

        if (playerTf != null)
            Debug.Log("Player transform correct");
        else
            Debug.Log("Player transform not found");
        
    }

    void Update()
    {
        // Recibe del componente trigger si el jugador está en el área del enemigo
        if (trigger.DetectPlayer())
        {
            if (CanSeePlayer() && !attackMode)
            {
                ChasePlayer();
            }
        }
        else
        {
            StopChasingPlayer();
        }
    }

    private bool CanSeePlayer()
    {
        bool val = false;

        int p, m, pm;
        p = 1 << LayerMask.NameToLayer("Player");
        m = 1 << LayerMask.NameToLayer("Muros");
        pm = p | m;

        if (playerTf == null)
            GetPlayerTransform();

        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTf.position, pm);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.GetComponent<PlayerController>() != null)
            {
                Debug.DrawLine(transform.position, playerTf.position, Color.white);
                val = true; //hit.distance <= detectRange;
            }
        }

        return val;
    }

    void ChasePlayer()
    {
        Vector2 trayectoria = playerTf.position - transform.position;

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

    public void DisminuirVelocidad(float disminucion)
    {
        speed *= disminucion;
        
    }

    public void AumentarVelocidad(float aumento)
    {
        speed /= aumento;
    } 

    public void RestablecerVelocidad()
    {
        speed = iniSpeed;
    }

    private void OnDisable()
    {
        Invoke("DevolverMovimiento", tiempoAturdimiento);
    }

    private void DevolverMovimiento()
    {
        this.enabled = true;
    }

}
