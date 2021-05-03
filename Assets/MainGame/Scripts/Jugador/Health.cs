using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxVida;
    LevelManager levels;

    [SerializeField] float vida;

    //public float Vida
    //{
    //    get
    //    {
    //        return vida;
    //    }
    //    set
    //    {
    //        vida = value;
    //        Debug.Log("vida: " + vida);
    //    }
    //}

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (vida == 0)
        {
            vida = maxVida;
            //GameManager.GetInstance().GMActualizarVida(GameManager.GetInstance().Vida / maxVida);
        }

        levels = LevelManager.GetInstance();
    }

    public void ReceiveDamage(float damage)
    {
        vida -= damage;
        GameManager.GetInstance().GMActualizarVida(vida / maxVida);

        Debug.Log("ReceiveDamage: " + vida);
        if (vida <= 0)
        {
            Destroy(this.gameObject);
            RespawnStart();
        }
                
    }

    private void RespawnStart()
    {
        // Vuelve al primer pasillo del nivel
        GameManager.GetInstance().ChangeScene("1P0");

        // Instancia al jugador
        GameManager.GetInstance().InstantiatePlayer();
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

    public void DamageOnFall()
    {   
        // El jugador pierde un cuarto de vida al caer por un precipicio
        vida -= maxVida / 4;
        GameManager.GetInstance().GMActualizarVida(vida / maxVida);
        Debug.Log("DamageOnFall: " + vida);

        if (vida <= 0)
        {
            Destroy(this.gameObject);
            RespawnStart();
        }
    }

    public void RespawnOnFall(Vector3 playerSpawnScale)
    {
        if (vida > 0)
        {
            transform.localScale = playerSpawnScale;
            LevelManager.GetInstance().SetUpPlayer(GameManager.GetInstance().GetOrientacion(), transform);

            Debug.Log("RespawnOnFall: " + vida);

            //transform.position = playerSpawnPos;
            //transform.rotation = playerSpawnRot;
        }
    }
}
