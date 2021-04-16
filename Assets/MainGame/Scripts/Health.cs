using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxVida;
    float vida;

    private void Start()
    {
        vida = maxVida;
    }

    internal void ReceiveDamage(float damage)
    {
        vida -= damage;
        GameManager.GetInstance().GMActualizarVida(vida / maxVida);

        Debug.Log("ReceiveDamage: " + vida);
        if (vida <= 0)       
            Destroy(this.gameObject);        
    }
}
