using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
public class Fall : MonoBehaviour
{
    GameObject character;
    float ogScale;
    Vector3 spawnScale;
    int i = 0;
    float maxDamage = 1000;


    private void FallSize()
    {
        if (character.transform.localScale.x < ogScale / 10)
        {
            Debug.Log("Size reached min");

            if (character.GetComponent<PlayerController>() != null)
            {
                Health playerHealth = character.GetComponent<Health>();
                playerHealth.DamageOnFall();
                character.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                character.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                RoomManager.GetInstance().LlamarImpedirSalida();
                playerHealth.RespawnOnFall(spawnScale);
            }
            else
            {
                EnemyHealth enemyHealth = character.GetComponent<EnemyHealth>();
                enemyHealth.QuitarVida(maxDamage);
            }     
            
            character = null;
        }
        else
        {
            Debug.Log("Reducing size");

            i++;
            character.transform.localScale *= 0.8f;
            Invoke("FallSize", 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter");

        if (collision.tag == "Centro")
        {
            if (character == collision.gameObject)
            {
                return;
            }

            character = collision.transform.parent.gameObject;
            ogScale = character.transform.localScale.x;
            spawnScale = character.transform.localScale;
            collision.gameObject.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            Invoke("FallSize", 0);
            Debug.Log("OgScale: " + ogScale);
        }
    }
}
*/

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
                GetComponentInParent<EnemyHealth>().QuitarVida(99999);
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
            GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            FallSize();
        }
    }
}
