using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField]
    private int maxMana;
    private float mana;

    

    void Awake()
    {
        mana = maxMana;
    }
    private void Start()
    {
        //InvokeRepeating("SumaMana", )
    }

    public bool RestaMana(int cantidad) //Se invoca al realizar una habilidad elemental, comprueba si se puede realizar el ataque y resta mana si es asi
    {
        bool manaSuficiente= (mana>=cantidad);
        bool max = (mana == maxMana);
        //Si hay suficiente mana como para restarle
        if (manaSuficiente)
        {
            mana -= cantidad;
        }
        //Debug.Log(mana);
        return manaSuficiente;
        
    }
    public void SumaMana(int cantidadRegenera) //Recupera cierta cantidad de mana cada cantidad determinada de tiempo por manaRegSpeed
    {
        //Suma cuando el mana sea menor que la cantidad maxima
        //Suma hasta que llegue a maxMana
        
        if(mana<maxMana && (mana + cantidadRegenera) < maxMana)
        {
            mana += cantidadRegenera;
        }
    }
    
}
