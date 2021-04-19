using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoFuego : MonoBehaviour
{
    [SerializeField]
    float shieldHealth = 20;

    float playerElementalAttack;


    EnemyHealth enemyHealth;
    void Start()
    {
        playerElementalAttack = GameManager.GetInstance().Stat("Agua"); //cogemos el bono agua
        //enemyHealth.enabled = false;                  //se desactiva el script de vida para no poder quitársela si tiene el escudo
    }

    void Update()
    {
        if (shieldHealth <= 0)
        {
            //enemyHealth.enabled = true;    //al destruirse le puedes quitar vida al enemigo

            Destroy(gameObject);                   //si la vida del escudo llega a 0 se destruye
        }
    }

    private void OnDestroy()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ActivateElementOnCollision>() != null)
        {
            string element = collision.GetComponent<ActivateElementOnCollision>().Elemento(); //como se hace esto wtf
            if (element == "Agua")
            {
                shieldHealth = 25;
            }
            else
            {
                shieldHealth = 3;
            }
        }
    }
}
