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
        GameManager.GetInstance().GMActualizarVida(vida / maxVida);
        DontDestroyOnLoad(this.gameObject);
    }

    public void ReceiveDamage(float damage)
    {
        vida -= damage;
        GameManager.GetInstance().GMActualizarVida(vida / maxVida);

        Debug.Log("ReceiveDamage: " + vida);
        if (vida <= 0)       
            Destroy(this.gameObject);        
    }

    public void Healing(float hp) //hacemos otro método para curar
    {
        if ((vida + hp) > maxVida) //para que no pueda tener más vida que la máxima
        {
            vida = maxVida;
        }
        else
            vida += hp;

        GameManager.GetInstance().GMActualizarVida(vida / maxVida);
    }
}
