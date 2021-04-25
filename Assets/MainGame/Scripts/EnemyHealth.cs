using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    bool escudo;
    public void QuitarVida(float cantidad)
    {
        if (GetComponent<Escudo>() != null) //Si hay escudo se comprueba si está en uso
            escudo = GetComponent<Escudo>().enabled;

        if (GetComponent<Escudo>() == null || !escudo) //si el enemigo no tiene escudo, se le daña
            health -= cantidad;
        Debug.Log(health);

        if (health <= 0)
        {
            Slime slime = GetComponent<Slime>();
            if (slime != null)
                slime.InstanciarSlimes();

            GameManager gameManager = GameManager.GetInstance();

            if (gameManager.juegoPrincipal)
            {
                if (gameManager.EsPasillo())
                    gameManager.MatarEnemigo(this.gameObject);
                else
                    gameManager.QuitarEnemigoSala();
                GetComponent<Enemy>().EstaMuerto();
            }                              
            Destroy(this.gameObject);
        }           
    }  
    public float Health()
    {
        return health;
    }

    public void EnemigoVidaIni(float vida)
    {
        health = vida;
    }
}
