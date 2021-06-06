using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Fall : MonoBehaviour
{
    Vector3 spawnScale;
    Transform size;
    EnemyHealth health;

    private void Start()
    {
        health = GetComponentInParent<EnemyHealth>();
        if (health != null)
            size = health.InfoTransform();
        else
            size = GetComponentInParent<Health>().InfoTransform();
        spawnScale = size.localScale;       
    }

    private void FallSize()
    {
        if (size.localScale.x <= 0)
        {
            if (health == null)
            {
                Health playerHealth = GetComponentInParent<Health>();
                playerHealth.DamageOnFall();
                GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                RoomManager.GetInstance().LlamarImpedirSalida();
                playerHealth.RespawnOnFall(spawnScale);
            }
            else
            {
                
                GetComponentInParent<EnemyHealth>().QuitarVida(999999);
            }              
        }
        else
        {
            Vector2 localSize = size.localScale;
            size.localScale = new Vector2(localSize.x - Time.deltaTime, localSize.y -Time.deltaTime);
            Invoke("FallSize", Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Precipicio"))
        {
            Slime slime = GetComponentInParent<Slime>();
            if (slime != null)
                Destroy(slime);
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            FallSize();
        }
    }
}
