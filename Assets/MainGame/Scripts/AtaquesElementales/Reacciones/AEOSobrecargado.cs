using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AEOSobrecargado : MonoBehaviour
{
    GameObject enemigoGolpeado;

    [SerializeField] 
    float diametro;

    [SerializeField]
    float knock;

    [SerializeField]
    float tiempoAturdimiento;

    float maxDamage;

    //El gameobject va creciendo hasta llegar a un diametro maximo y despues se destruye
    void Start() 
    {
        transform.localScale = new Vector2(diametro, diametro);
        Destroy(gameObject, Time.deltaTime);
    }
    //Aquellos enemigos con los que colisione este trigger seran impulsados y se les restara vida
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.GetInstance().explotionSound();
        EnemyHealth health = collision.GetComponent<EnemyHealth>();
        ;

        //Comprueba si aquello con lo que colisiona es un enemigo (solo los enemigos tienen el componente enemy health)
        if (health != null && collision.gameObject != enemigoGolpeado) 
        {       
            Vector2 direction = (collision.transform.position - transform.position);
            //la explosion afecta más a los enemigos que estén más cerca de la explosión
            float relacionDistancia = 1 - direction.magnitude / diametro;
            //Daño
            health.QuitarVida(maxDamage * relacionDistancia);
            //Knockback
            EnemyMovement enemyMovement = collision.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.Knockback(tiempoAturdimiento);
                collision.GetComponent<Rigidbody2D>().AddForce(direction.normalized * knock * relacionDistancia, ForceMode2D.Impulse);
            }            
        }
    }

    public void EnemigoGolpeado(GameObject collision) { enemigoGolpeado = collision; }
 
    public void Knockback(out float _knock, out float _tiempoAturdimiento)
    {
        _knock = knock;
        _tiempoAturdimiento = tiempoAturdimiento;
    }

    public void Damage(float damage)
    {
        maxDamage = damage;
    }
}
