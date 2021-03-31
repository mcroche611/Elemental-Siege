﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    [SerializeField] float escaladoDeDaño = 0.3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy)
            enemy.QuitarVida(Formula());
    }

    private float Formula()
    {
        float bonoAlDaño = GameManager.GetInstance().Stat(GetComponent<ActivateElementOnCollision>().Elemento());
        float ataque = GameManager.GetInstance().Stat("");
        return (ataque + bonoAlDaño) * escaladoDeDaño;
    }
}
