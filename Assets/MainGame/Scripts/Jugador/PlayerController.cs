using System.Collections;
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

    bool seMueve = false; //bool para ver si el jugador se está moviendo en alguna dirección
                               //y animarlo

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
        if (Time.timeScale == 1f)
        {
            animator.SetBool("seMueve", seMueve);
            RunningAnimation();

            if (aturdido <= 0)
            {
                //Input de movimiento de cuatro direccones y movimiento en diagonal
                vel = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
                //Velocidad de Movimiento
                rb.velocity = new Vector2(vel.x * velocity, vel.y * velocity);
                if (rb.velocity.x < 0) //si en el eje de laas x está yendo a la izquierda, hacemos flip al sprite
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                else if (rb.velocity.x > 0) //no ponemos un else porque si no también se cambia al ir en vertical
                {
                    gameObject.GetComponent<SpriteRenderer>().flipX = false;
                }
            }
            else
                aturdido -= Time.deltaTime;
        }      
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
            seMueve = true;
        }
        else
        {
            seMueve = false;
        }
    }
}
