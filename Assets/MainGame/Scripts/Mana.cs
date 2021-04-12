using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField]
    private int maxMana;

    [SerializeField]
    private float manaRegSpeed;

    private float mana;

    void Awake()
    {
        mana = maxMana;
    }
    private void Start()
    {
        //Recupera cierta cantidad de mana cada cantidad determinada de tiempo por manaRegSpeed
        InvokeRepeating("SumaMana", manaRegSpeed, manaRegSpeed); 
    }

    public bool RestaMana(int cantidad) //Se invoca al realizar una habilidad elemental, comprueba si se puede realizar el ataque y resta mana si es asi
    {
        bool manaSuficiente= (mana>=cantidad);
        bool max = (mana == maxMana);
        //Si hay suficiente mana como para restarle
        if (manaSuficiente)
        {
            mana -= cantidad;
            GameManager.GetInstance().GMActualizarMana(mana / maxMana);
        }

        Debug.Log("Mana: " + mana);
        return manaSuficiente;
        
        
    }
    public void SumaMana() 
    {
        
        if(mana<maxMana)
        {
            mana += 1;
            GameManager.GetInstance().GMActualizarMana(mana / maxMana);
        }
       
    }
    private void OnDestroy()
    {
        CancelInvoke("SumaMana");
    }

}
