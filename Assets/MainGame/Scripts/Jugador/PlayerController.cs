﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declarar las variables
    [SerializeField] 
    float velocity;

    Animator animator;

    Rigidbody2D rb;
    Vector2 vel;

    bool runningRight = false; //bool para ver si el jugador se está moviendo en alguna dirección
                               //y animarlo
    bool runningLeft = false;
    float aturdido = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        GameManager.GetInstance().SetPlayer(this.gameObject);
        //Cacheamos el componente Rigidbody
        rb = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        RunningAnimation();
        Debug.Log("MOVIMIENTO HORIZONTAL" + Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        animator.SetBool("RunningRight", runningRight);
        //animator.SetBool()
        animator.SetBool("RunningLeft", runningLeft);
        //animator.SetBool();
        if (aturdido <= 0)
        {
            //Input de movimiento de cuatro direccones y movimiento en diagonal
            vel = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            //Velocidad de Movimiento
            rb.velocity = new Vector2(vel.x * velocity, vel.y * velocity);
        }
        else
            aturdido -= Time.deltaTime;
    }

    public void Ralentizado(float porcentaje)
    {
        velocity = velocity * porcentaje;
    }

    public void NoRalentizado(float porcentaje)
    {
        velocity = velocity / porcentaje;
    }

    public void Knockback(float tiempoAturdimiento)
    {
        rb.velocity = new Vector2(0f, 0f);
        aturdido = tiempoAturdimiento;
    }

    void RunningAnimation()
    {
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0 || Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0)
        {
            runningRight = true;

            if (Input.GetAxisRaw("Horizontal")<0)
            {
                runningRight = false;

                runningLeft = true;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                runningLeft = false;

                runningRight = true;

            }
        }
        else
        {
            runningRight = false;
            runningLeft = false;

        }
    }
}
