using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscudoFuego : MonoBehaviour
{
    [SerializeField]
    float shieldHealth = 20;

    float playerElementalAttack;

    private void OnEnable()
    {
        GetComponent<SpriteRenderer>().color = Color.red; //tonteria visual para ver si tiene el escudo o no
    }
    void Start()
    {
        playerElementalAttack = GameManager.GetInstance().Stat("Agua"); //cogemos el bono agua
        //enemyHealth.enabled = false;                  //se desactiva el script de vida para no poder quitársela si tiene el escudo
    }

    void Update()
    {
        if (shieldHealth <= 0)
        {
            GetComponent<EscudoFuego>().enabled = false;    //si la vida del escudo llega a 0 se desactiva
        }
    }

    private void OnDisable()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow; //se le pone otro color al desaparecer
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ActivateElementOnCollision>() != null)
        {
            string element = collision.GetComponent<ActivateElementOnCollision>().Elemento(); //como se hace esto wtf
            if (element == "Agua")
            {
                shieldHealth -= playerElementalAttack;
            }
            else
            {
                shieldHealth -= 2;
            }
        }
    }
}
