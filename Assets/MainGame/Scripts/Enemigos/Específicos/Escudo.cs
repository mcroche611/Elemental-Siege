using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Escudo : MonoBehaviour
{
    //Comportamiento de los escudos de los enemigos. 
    //Hay un bool que detecta este componente antes de hacer daño en EnemyHealth

    [SerializeField]
    float shieldHealth = 20;
    float maxShieldHealth;

    [SerializeField]
    string shieldType = "Fuego"; //puede ser "Fuego", "Agua" o "Electrico" sin tilde

    bool escudoFuego;
    bool escudoAgua;
    bool escudoElectrico;

    //el bonus del jugador de cada ataque elemental
    float playerWaterBonus;
    float playerFireBonus;
    float playerElectricBonus;

    public GameObject barraDeEscudo;
    RectTransform _barraDeEscudo;
    float maxBarraDeEscudo;

    private void OnEnable()
    {


        //sacamos los bools al activarse el script para hacerlo menos veces
        if (shieldType == "Fuego")
        {
             escudoFuego = true;
            GetComponent<SpriteRenderer>().color = Color.red;
        }
           
        else if (shieldType == "Agua")
        {
            escudoAgua = true;
            GetComponent<SpriteRenderer>().color = Color.blue;
        }
            
        else if (shieldType == "Electrico")
        {
            escudoElectrico = true;
            GetComponent<SpriteRenderer>().color = Color.magenta;
        }
           

        
        _barraDeEscudo = barraDeEscudo.GetComponent<RectTransform>();
        maxBarraDeEscudo = _barraDeEscudo.sizeDelta.x;
        maxShieldHealth = shieldHealth;
    }
    void Start() //si usamos este script para el boss, necesitamos pillar todos los bonus
                 //porque si no al cambiar de escudo, lo ejecutado en el start ya estará puesto
    {
        playerWaterBonus = GameManager.GetInstance().Stat("Agua"); //cogemos el bono agua
        playerFireBonus = GameManager.GetInstance().Stat("Fuego"); //cogemos el bono fuego
        playerElectricBonus = GameManager.GetInstance().Stat("Electrico"); //cogemos el bono electrico


    }

    void Update()
    {
        if (shieldHealth <= 0)
        {
            GetComponent<Escudo>().enabled = false;    //si la vida del escudo llega a 0 se desactiva
        }
    }

    private void OnDisable()
    {
        GetComponent<SpriteRenderer>().color = Color.yellow; //se le pone otro color al desaparecer
        
            escudoFuego = false;
            escudoAgua = false;
            escudoElectrico = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ActivateElementOnCollision>() != null)
        {
            string element = collision.GetComponent<ActivateElementOnCollision>().Elemento(); //como se hace esto wtf
            if (escudoFuego)
            {
                if (element == "Agua")
                {
                    shieldHealth -= playerWaterBonus;
                }
                else
                {
                    shieldHealth -= 2;
                }
            }
            else if (escudoAgua)
            {
                if (element == "Electricidad")
                {
                    shieldHealth -= playerElectricBonus;
                }
                else
                {
                    shieldHealth -= 2;
                }
            }
            else if (escudoElectrico)
            {
                if (element == "Fuego")
                {
                    shieldHealth -= playerFireBonus;
                }
                else
                {
                    shieldHealth -= 2;
                }
            }
            _barraDeEscudo.sizeDelta = new Vector2((maxBarraDeEscudo) * (shieldHealth / maxShieldHealth), _barraDeEscudo.sizeDelta.y);
        }
    }

    public void CambioEscudo(string type)
    {
        shieldType = type;
        shieldHealth = maxShieldHealth;
    }
    
    public float ShieldHealth() //Devuelve el valor de vida de escudo
    {
        return shieldHealth;
    }
    public string TipoEscudo() //Devuelve el tipo de escudo que se está usando
    {
        return shieldType;
    }
}
