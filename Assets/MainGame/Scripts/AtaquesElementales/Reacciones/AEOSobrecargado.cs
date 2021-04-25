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

    //El gameobject va creciendo hasta llegar a un diametro maximo y despues se destruye
    void Start() 
    {
        transform.localScale = new Vector2(diametro, diametro);
        Destroy(gameObject, Time.deltaTime);
    }
    //Aquellos enemigos con los que colisione este trigger seran impulsados y se les restara vida
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyMovement enemyMovement = collision.GetComponent<EnemyMovement>();

        //Comprueba si aquello con lo que colisiona es un enemigo (solo los enemigos tienen el componente enemy health)
        if (enemyMovement != null && collision.gameObject != enemigoGolpeado) 
        {
            enemyMovement.enabled = false;
            //Knockback
            Rigidbody2D rbEnemie = collision.GetComponent<Rigidbody2D>();
            Vector2 direction = (rbEnemie.transform.position - transform.position);
            //el Knockback afecta más a los enemigos que estén más cerca de la explosión
            rbEnemie.AddForce(direction.normalized * (knock * (1 - direction.magnitude / diametro)), ForceMode2D.Impulse);
        }
    }

    public void EnemigoGolpeado(GameObject collision) { enemigoGolpeado = collision; }
 
    public float Knockback() { return knock; }
}
