using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declarar las variables
    [SerializeField] 
    float velocity;

    Rigidbody2D rb;
    Vector2 vel;

    float aturdido = 0;


    private void Awake()
    {
        if (GameManager.GetInstance() != null)
            if (GameManager.GetInstance().Nasnas(this.gameObject))
                Destroy(this.gameObject);
    }

    void Start()
    {
        GameManager.GetInstance().SetPlayer(this.gameObject);
        //Cacheamos el componente Rigidbody
        rb = GetComponent<Rigidbody2D>();
        //LevelManager.GetInstance().SetPlayerTransform(this.gameObject.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aturdido <= 0)
        {
            //Input de movimiento de cuatro direccones y movimiento en diagonal
            vel = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
            //Velocidad de Movimiento
            if (rb != null)
                rb.velocity = new Vector2(vel.x * velocity, vel.y * velocity);
            else
                rb = GetComponent<Rigidbody2D>();
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
}
