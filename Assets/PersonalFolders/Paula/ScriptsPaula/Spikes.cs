using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField]
    int playerSpikesDamage; //Daño de los pinchos al jugador
    [SerializeField]
    int playerDamageDuration; //Tiempo durante el cual se resta vida al jugador
    [SerializeField]
    int enemySpikesDamage;  //Daño de los pinchos al enemigo
    [SerializeField]
    int enemyDamageDuration;    //Tiempo durante el cual se resta vida al jugador
    Health playerHealth;
    EnemyHealth enemyHealth;
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth = collision.GetComponent<Health>();
        enemyHealth = collision.GetComponent<EnemyHealth>();
        /*IMPORTANTE: solo deben colisionar con los pinchos el jugador y los enemigos 
         * en la matriz de colisiones a la hora de usr esta implementacion*/

        //En este caso es el jugador quien entra en el trigger
        if (playerHealth != null)
        {
            InvokeRepeating("DamagePlayer", 0, playerDamageDuration);
        }
        else
        {
            InvokeRepeating("DamageEnemy", 0, enemyDamageDuration);
        }
           
    }
    //Accede al metodo que resta vida al jugador
    void DamagePlayer()
    {
        playerHealth.ReceiveDamage(playerSpikesDamage);
    }
    //Accede al metodo que resta vida al enemigo
     /*void DamageEnemy()
     {
        enemyHealth.QuitarVida(enemySpikesDamage);
     }*/
}
