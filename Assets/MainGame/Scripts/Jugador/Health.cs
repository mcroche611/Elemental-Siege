using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxVida;
    //[SerializeField] GameObject playerPrefab;
    LevelManager levels;
    //Vector3 initialScale;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (GameManager.GetInstance().Vida == 0)
            GameManager.GetInstance().Vida = maxVida;

        //GameManager.GetInstance().GMActualizarVida(vida / maxVida);

        levels = LevelManager.GetInstance();
        //initialScale = levels.GetPlayerTransform().localScale;
    }

    public void ReceiveDamage(float damage)
    {
        GameManager.GetInstance().Vida -= damage;
        GameManager.GetInstance().GMActualizarVida(GameManager.GetInstance().Vida / maxVida);

        Debug.Log("ReceiveDamage: " + GameManager.GetInstance().Vida);
        if (GameManager.GetInstance().Vida <= 0)       
            Destroy(this.gameObject);        
    }

    public void Healing(float hp) //hacemos otro método para curar
    {
        if ((GameManager.GetInstance().Vida + hp) > maxVida) //para que no pueda tener más vida que la máxima
        {
            GameManager.GetInstance().Vida = maxVida;
        }
        else
            GameManager.GetInstance().Vida += hp;

        GameManager.GetInstance().GMActualizarVida(GameManager.GetInstance().Vida / maxVida);
    }

    public void DamageOnFall()
    {   
        // El jugador pierde un cuarto de vida al caer por un precipicio
        GameManager.GetInstance().Vida -= maxVida / 4;
        Debug.Log("DamageOnFall: " + GameManager.GetInstance().Vida);
    }

    public void RespawnOnFall()
    {
        //Transform playerTf = levels.GetPlayerTransform();
        //playerTf.localScale = initialScale;

        GameManager.GetInstance().InstantiatePlayer();

        //playerClone.transform.localScale *= 10;

        Debug.Log("RespawnOnFall: " + GameManager.GetInstance().Vida);
    }
}
