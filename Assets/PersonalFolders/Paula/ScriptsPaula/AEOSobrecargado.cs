using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEOSobrecargado : MonoBehaviour
{
    [SerializeField] 
    float diametro;
    [SerializeField]
    float knock;

    //El gameobject va creciendo hasta llegar a un diametro maximo y despues se destruye
    void Start() 
    {
        transform.localScale = new Vector2(diametro, diametro);
        Destroy(gameObject, Time.deltaTime);
    }
    //Aquellos enemigos con los que colisione este trigger seran impulsados y se les restara vida
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Comprueba si aquello con lo que colisiona es un enemigo (solo los enemigos tienen el componente enemy health)
        if (collision.gameObject.GetComponent<EnemyHealth>() != null) 
        {
            collision.GetComponent<EnemyMovement>().enabled = false;

            //Knockback

            Rigidbody2D rbEnemies = collision.GetComponent<Rigidbody2D>();
            Vector2 direction = (rbEnemies.transform.position - transform.position).normalized;
            rbEnemies.AddForce(direction * knock, ForceMode2D.Impulse);
            
        }
        
    }
    
}
