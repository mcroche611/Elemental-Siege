using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;
    float maxHealth;

    public GameObject barraDeVida;
    RectTransform _barraDeVida;
    float maxBarraDeVida;

    private void Start()
    {
        _barraDeVida = barraDeVida.GetComponent<RectTransform>();
        maxBarraDeVida = _barraDeVida.sizeDelta.x;
        maxHealth = health;
    }


    public void QuitarVida(float cantidad)
    {
        Escudo escudo = GetComponent<Escudo>();

        if (!(escudo != null && escudo.enabled) && !(health <= 0))
        {
            health -= cantidad;
            barraDeVida.SetActive(true);
            _barraDeVida.sizeDelta = new Vector2((maxBarraDeVida) * (health / maxHealth), _barraDeVida.sizeDelta.y);

            if (health <= 0)
            {
                Slime slime = GetComponent<Slime>();
                if (slime != null)
                    slime.InstanciarSlimes();

                LevelManager levelmanager = LevelManager.GetInstance();

                if (levelmanager.TipoHabitacion() == 'P')
                {
                    levelmanager.MatarEnemigo(this.gameObject);
                    GetComponent<Enemy>().EstaMuerto();
                }                 
                else
                    levelmanager.QuitarEnemigoSala();
                
                Destroy(this.gameObject);
            }                                   
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
