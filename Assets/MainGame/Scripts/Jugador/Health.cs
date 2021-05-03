using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxVida;

    [SerializeField] float vida;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (vida == 0)
        {
            vida = maxVida;
        }
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
        // Resetea el avance en el nivel
        GameManager.GetInstance().CreaNivel1();

        // Cosas de los Start()
        GameManager.GetInstance().restartJuego = true;

        // Vuelve al primer pasillo del nivel
        GameManager.GetInstance().ChangeScene("1P0");

        //GameManager.GetInstance().SetPlayer(this.gameObject);
        //LevelManager.GetInstance().SetUpCamera(gameObject.transform);
        //LevelManager.GetInstance().SetUpPlayer("Este", GameManager.GetInstance().GetPlayerTransform());
        vida = maxVida;
        GameManager.GetInstance().GMActualizarVida(vida / maxVida);
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
        }
    }
}
