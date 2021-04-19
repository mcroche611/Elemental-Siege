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
    int enemyDamageDuration;   //Tiempo durante el cual se resta vida al jugador
    [SerializeField]
    float playerSpeedReduction;   //Proporcion en la que se reduce la velocidad del jugador
    [SerializeField]
    float enemySpeedReduction; //Proporcion en la que se reduce la velocidad del enemigo

    Health playerHealth;
    EnemyHealth enemyHealth;
    PlayerController playerSpeed;
    EnemyMovement enemySpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        /*IMPORTANTE: solo deben colisionar con los pinchos el jugador y los enemigos 
         * en la matriz de colisiones a la hora de usr esta implementacion*/

        //En este caso es el jugador quien entra en el trigger
        playerHealth = collision.GetComponent<Health>();
       
        if (playerHealth != null)
        {
            playerSpeed = collision.GetComponent<PlayerController>();
            InvokeRepeating("DamagePlayer", 0, playerDamageDuration);
            Invoke("ReducePlayerSpeed", 0);
        }
        else
        {
            enemySpeed = collision.GetComponent<EnemyMovement>();
            enemyHealth = collision.GetComponent<EnemyHealth>();
            InvokeRepeating("DamageEnemy", 0, enemyDamageDuration);
            Invoke("ReduceEnemySpeed", 0);
        }      
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerHealth = collision.GetComponent<Health>();
        if (playerHealth != null)
        {
            CancelInvoke("DamagePlayer");
            Invoke("ReturnPlayerSpeed",0);
        }
        else
        {
            CancelInvoke("DamageEnemy");
            CancelInvoke("ReduceEnemySpeed");
            Invoke("ReturnEnemySpeed", 0);
        }     
    }
    //Accede al metodo que resta vida al jugador
    void DamagePlayer()
    {
        playerHealth.ReceiveDamage(playerSpikesDamage);
    }
    //Accede al metodo que resta vida al enemigo
    void DamageEnemy()
    {
        enemyHealth.QuitarVida(enemySpikesDamage);
    }
    void ReducePlayerSpeed()
    {       
        playerSpeed.Ralentizado(playerSpeedReduction);
    }
    void ReturnPlayerSpeed()
    {
        playerSpeed.NoRalentizado(playerSpeedReduction);
    }
    void ReduceEnemySpeed()
    {     
        enemySpeed.DisminuirVelocidad(enemySpeedReduction);
    }   
    private void ReturnEnemySpeed()
    {
        enemySpeed.AumentarVelocidad(enemySpeedReduction);
    }
}
