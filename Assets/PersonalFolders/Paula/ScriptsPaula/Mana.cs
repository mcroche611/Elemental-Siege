using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField]
    private int maxMana;
    private float mana;

    [SerializeField]
    private float manaRegSpeed;

    void Awake()
    {
        mana = maxMana;
    }

    
    void Update()
    {
        if (mana < maxMana)
        {
            mana += manaRegSpeed * Time.deltaTime;
        }
        else mana = maxMana;
        /*if (Input.GetKeyDown("space"))
        {
            RestaMana(30);
        }
        Debug.Log(mana);*/
    }
    public void RestaMana(int cantidad) //Se invoca al realizar una habilidad elemental
    {
        if (mana >= cantidad)
        {
            mana -= cantidad;
        }

    }
}
