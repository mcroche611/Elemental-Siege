using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declarar las variables
    [SerializeField] 
    float velocity;

    [SerializeField]
    float tiempoAturdimiento;

    Rigidbody2D rb;
    bool ralentizado;
    float newVelocity;
    void Start()
    {
        GameManager.GetInstance().SetPlayer(this.gameObject);
        //Cacheamos el componente Rigidbody
        rb = GetComponent<Rigidbody2D>();
        ralentizado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Input de movimiento de cuatro direccones y movimiento en diagonal
        Vector2 vel = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        //Velocidad de Movimiento
        if (ralentizado)
        {
            velocity = velocity-(velocity* newVelocity);
            
        }
        rb.velocity = new Vector2(vel.x * velocity, vel.y * velocity);
        
    }

    private void OnDisable()
    {
        Invoke("RecuperarMovimiento", tiempoAturdimiento);
    }

    private void RecuperarMovimiento()
    {
        this.enabled = true;
    }
    public void Ralentizado(ref float porcentaje)
    {
        ralentizado = true;
        newVelocity = porcentaje;
    }
    public void NoRalentizado()
    {
        ralentizado = false;
    }
}
