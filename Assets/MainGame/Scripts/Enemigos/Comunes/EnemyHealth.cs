using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] 
    float health;
    [SerializeField]
    Animator animator;
    float maxHealth;
    public GameObject barraDeVida;
    RectTransform _barraDeVida;
    float maxBarraDeVida;
    public AudioSource sonidoDeMorir;
    private void Start()
    {
        _barraDeVida = barraDeVida.GetComponent<RectTransform>();
        maxBarraDeVida = _barraDeVida.sizeDelta.x;
        maxHealth = health;
        sonidoDeMorir = GetComponent<AudioSource>();
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
                sonidoDeMorir.Play();
                Slime slime = GetComponent<Slime>();
                if (slime != null)
                    slime.InstanciarSlimes();
                     
                LevelManager levelmanager = LevelManager.GetInstance();

                if (levelmanager != null)
                {
                    if (levelmanager.TipoHabitacion() == 'P')
                    {
                        levelmanager.MatarEnemigo(this.gameObject);
                        GetComponent<Enemy>().EstaMuerto();
                    }
                    else
                        levelmanager.QuitarEnemigoSala();
                }
                if (slime == null)
                {

                    animator.SetBool("muere", true);
                    Invoke("Destruye", 0.5f);
                }
                else Destroy(this.gameObject);
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
    void Destruye()
    {
        Destroy(this.gameObject);
    }

    public Transform InfoTransform()
    {
        return transform;
    }
}
