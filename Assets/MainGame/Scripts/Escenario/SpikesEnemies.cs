using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesEnemies : MonoBehaviour
{
    [SerializeField]
    float relentizacion;

    [SerializeField]
    float spikesDamge;

    [SerializeField]
    float CoolDown;

    bool pisaSpike = false;
    EnemyHealth health;
    EnemyMovement speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Spikes") && !pisaSpike)
        {
            pisaSpike = true;
            this.enabled = true;
            speed = GetComponentInParent<EnemyMovement>();
            speed.DisminuirVelocidad(relentizacion);
            health = GetComponentInParent<EnemyHealth>();
            InvokeRepeating("Damage", 0, CoolDown);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pisaSpike = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Spikes"))
        {
            pisaSpike = true;
        }
    }

    private void Update()
    {
        if (!pisaSpike)
        {
            speed.AumentarVelocidad(relentizacion);
            CancelInvoke("Damage");
            this.enabled = false;
        }
    }

    void Damage()
    {
        health.QuitarVida(spikesDamge);
    }
}
