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
        DontDestroyOnLoad(this.gameObject);

        vida = maxVida;
        GameManager.GetInstance().GMActualizarVida(vida / maxVida);
    }

    public void ReceiveDamage(float damage)
    {
        if (vida > 0)
        {
            vida -= damage;
            GameManager.GetInstance().GMActualizarVida(vida / maxVida);

            Debug.Log("ReceiveDamage: " + vida);
            if (vida <= 0)
            {
                SoundManager.GetInstance().playerDeathSound();
                Destroy(this.gameObject);
                if (LevelManager.GetInstance() != null)
                    LevelManager.GetInstance().PrimeraHabitacion();
            }
        }             
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

        if (vida <= 0)
        {
            Destroy(this.gameObject);
            LevelManager.GetInstance().PrimeraHabitacion();
        }
    }

    public void RespawnOnFall(Vector3 playerSpawnScale)
    {
        if (vida > 0)
        {
            transform.localScale = playerSpawnScale;
            RoomManager.GetInstance().SetUpPlayer(LevelManager.GetInstance().GetOrientacion(), transform);

            Debug.Log("RespawnOnFall: " + vida);
        }
    }
}
