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
    float playerSpeedReduction;   //Porcentaje en el que se reduce la velocidad del jugador
    [SerializeField]
    float enemySpeedReduction; //Porcentaje en el que se reduce la velocidad del enemigo

    Health playerHealth;
    EnemyHealth enemyHealth;
    PlayerController playerSpeed;
    EnemyMovement enemySpeed;

    private void Start()
    {
        playerHealth = null;
        enemyHealth = null;
        playerSpeed = null;
        enemySpeed = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        /*IMPORTANTE: solo deben colisionar con los pinchos el jugador y los enemigos 
         * en la matriz de colisiones a la hora de usr esta implementacion*/

        //En este caso es el jugador quien entra en el trigger
        playerHealth = collision.GetComponent<Health>();
        playerSpeed = collision.GetComponent<PlayerController>();
        if (playerHealth != null)
        {
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
        
        CancelInvoke("DamagePlayer");
        CancelInvoke("DamageEnemy");
        Invoke("ReturnPlayerSpeed", 0);
        CancelInvoke("ReduceEnemySpeed");
        //Invoke("ReturnEnemySpeed", 0);
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
        playerSpeedReduction = playerSpeedReduction / 100;
        playerSpeed.Ralentizado(ref playerSpeedReduction);
    }
    void ReturnPlayerSpeed()
    {
        playerSpeed.NoRalentizado();
    }
    void ReduceEnemySpeed()
    {
        enemySpeedReduction = enemySpeedReduction / 100;
        enemySpeed.DisminuirSpikes(enemySpeedReduction);
    }
    
    /*private void ReturnEnemySpeed()
    {
        enemySpeed.RestablecerVelocidad();
    }*/
}
