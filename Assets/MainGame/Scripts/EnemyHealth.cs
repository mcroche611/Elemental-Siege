﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    public void QuitarVida(float cantidad)
    {
        health -= cantidad;
        Debug.Log(health);

        if (health <= 0)
        {
            Slime slime = GetComponent<Slime>();
            if (slime != null)
                slime.InstanciarSlimes();
            Destroy(this.gameObject);
        }           
    }   
}
