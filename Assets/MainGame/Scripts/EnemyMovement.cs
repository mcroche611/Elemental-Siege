﻿using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float detectRange;

    [SerializeField]
    float speed;

    [SerializeField]
    float tiempoAturdimiento;

    Vector2 vel;
    bool attackMode = false;

    float iniSpeed;
    Transform playerTf;
    Rigidbody2D rb;

    void Start()
    {
        iniSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        GetPlayerTransform();
    }

    private void GetPlayerTransform()
    {
        playerTf = GameManager.GetInstance().GetPlayerTransform();

        if (playerTf != null)
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

        if (playerTf == null)
            GetPlayerTransform();
        
        RaycastHit2D hit = Physics2D.Linecast(transform.position, playerTf.position, pm);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.GetComponent<PlayerController>() != null)
            {
                val = hit.distance <= detectRange;
            }
        }

        Debug.DrawLine(transform.position, playerTf.position, Color.white);

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
        speed = speed * disminucion;
        Debug.Log(speed);
    }

    public void RestablecerVelocidad()
    {
        speed = iniSpeed;
        Debug.Log(speed);
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