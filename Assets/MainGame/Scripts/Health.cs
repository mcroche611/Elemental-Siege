using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float vidaPlayer;

    internal void ReceiveDamage(float damage)
    {
        vidaPlayer -= damage;

        Debug.Log("ReceiveDamage: " + vidaPlayer);
        if (vidaPlayer <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
