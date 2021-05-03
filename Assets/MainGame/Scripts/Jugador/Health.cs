using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxVida;
    LevelManager levels;

    [SerializeField] private float vida;

    public float Vida
    {
        get
        {
            return vida;
        }
        set
        {
            vida = value;
            Debug.Log("vida: " + vida);
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Vida == 0)
        {
            Vida = maxVida;
            //GameManager.GetInstance().GMActualizarVida(GameManager.GetInstance().Vida / maxVida);
        }

        levels = LevelManager.GetInstance();
    }

    public void ReceiveDamage(float damage)
    {
        Vida -= damage;
        GameManager.GetInstance().GMActualizarVida(Vida / maxVida);

        Debug.Log("ReceiveDamage: " + Vida);
        if (Vida <= 0)       
            Destroy(this.gameObject);        
    }

    public void Healing(float hp) //hacemos otro método para curar
    {
        if ((Vida + hp) > maxVida) //para que no pueda tener más vida que la máxima
        {
            Vida = maxVida;
        }
        else
            Vida += hp;

        GameManager.GetInstance().GMActualizarVida(Vida / maxVida);
    }

    public void DamageOnFall()
    {   
        // El jugador pierde un cuarto de vida al caer por un precipicio
        Vida -= maxVida / 4;
        GameManager.GetInstance().GMActualizarVida(Vida / maxVida);
        Debug.Log("DamageOnFall: " + Vida);
    }

    public void RespawnOnFall(Vector3 playerSpawnScale)
    {
        if (Vida > 0)
        {
            transform.localScale = playerSpawnScale;
            LevelManager.GetInstance().SetUpPlayer(GameManager.GetInstance().GetOrientacion(), transform);

            //GameManager.GetInstance().InstantiatePlayer();
            Debug.Log("RespawnOnFall: " + Vida);

            //transform.position = playerSpawnPos;
            //transform.rotation = playerSpawnRot;
        }
    }
}
