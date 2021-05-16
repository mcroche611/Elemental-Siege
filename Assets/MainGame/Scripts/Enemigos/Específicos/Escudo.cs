using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    //Comportamiento de los escudos de los enemigos. 
    //Hay un bool que detecta este componente antes de hacer daño en EnemyHealth

    [SerializeField]
    float shieldHealth = 20;
    float maxShieldHealth;

    [SerializeField]
    string shieldType;

    //el bonus del jugador de cada ataque elemental
    float bonoAgua, bonoFuego, bonoElectricidad;

    public GameObject barraDeEscudo;
    RectTransform _barraDeEscudo;
    float maxBarraDeEscudo;

    private void OnEnable()
    {
        //sacamos los bools al activarse el script para hacerlo menos veces
       /* if (shieldType == "Fuego")   
            GetComponent<SpriteRenderer>().color = Color.red;                 
        else if (shieldType == "Agua")
            GetComponent<SpriteRenderer>().color = Color.blue;                 
        else
            GetComponent<SpriteRenderer>().color = Color.magenta;*/
                      
        _barraDeEscudo = barraDeEscudo.GetComponent<RectTransform>();
        maxBarraDeEscudo = _barraDeEscudo.sizeDelta.x;
        maxShieldHealth = shieldHealth;
    }
    void Start()              
    {
        bonoAgua = GameManager.GetInstance().Stat("Agua");
        bonoFuego = GameManager.GetInstance().Stat("Fuego");
        bonoElectricidad = GameManager.GetInstance().Stat("Electricidad");
    }

    private void OnDisable()
    {
        //GetComponent<SpriteRenderer>().sprite = guardiaNeutro; //se le pone otro color al desaparecer       
    }

    public void AtaqueEscudo(string element)
    {
        if (shieldType == "Fuego")
        {
            if (element == "Agua")
                shieldHealth -= bonoAgua;
            else if (element == "Electricidad")
                shieldHealth -= bonoElectricidad / 4;
        }                                 
        else if (shieldType == "Agua")
        {
            if (element == "Electricidad")
                shieldHealth -= bonoElectricidad;
            else if (element == "Fuego")
                shieldHealth -= bonoFuego / 4;
        }
        else
        {
            if (element == "Fuego")
                shieldHealth -= bonoFuego;
            else if (element == "Agua")
                shieldHealth -= bonoAgua / 4;
        }     
                         
        _barraDeEscudo.sizeDelta = new Vector2((maxBarraDeEscudo) * (shieldHealth / maxShieldHealth), _barraDeEscudo.sizeDelta.y);
        if (shieldHealth <= 0)
            Invoke("DescativarEscudo", Time.deltaTime);                 
    }

    void DescativarEscudo()
    {
        GetComponent<Escudo>().enabled = false;
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
