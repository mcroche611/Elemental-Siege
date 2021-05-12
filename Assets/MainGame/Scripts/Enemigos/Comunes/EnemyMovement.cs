using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Animator animator;

    Vector2 vel;
    bool attackMode = false;

    float aturdido;
    float iniSpeed;
    bool seMueve=false; //Variable para controlar la animación del enemigo paso de Idle a correr
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
        animator.SetBool("seMueve", seMueve);
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
        seMueve = true;
        Vector2 trayectoria = playerTf.position - transform.position;

        vel = trayectoria.normalized;
    }

    private void StopChasingPlayer()
    {
        seMueve = false;
        vel.x = 0;
        vel.y = 0;
    }

    private void FixedUpdate()
    {
        if (aturdido <= 0)
        {
            rb.velocity = new Vector2(vel.x * speed, vel.y * speed);
            if (rb.velocity.x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX=true;
            }
            else gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
            
        else
            aturdido -= Time.deltaTime;
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

    public void Knockback(float tiempoAturdimiento)
    {
        if (gameObject.name != "ArcherBien")
        {
            rb.velocity = new Vector2(0f, 0f);
            aturdido = tiempoAturdimiento;
        }       
    }
}
