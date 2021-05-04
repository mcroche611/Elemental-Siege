using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    GameObject character;
    float ogScale;
    Vector3 spawnScale;
    int i = 0;
    float maxDamage = 1000;


    private void FallSize()
    {
        Debug.Log("FallSize: Scale: " + character.transform.localScale.x + " OgScale: " + ogScale + " Fall #: " + i);

        if (character.transform.localScale.x < ogScale / 10)
        {
            Debug.Log("Size reached min");

            if (character.GetComponent<PlayerController>() != null)
            {
                Health playerHealth = character.GetComponent<Health>();
                playerHealth.DamageOnFall();

                // reestablece el movimiento cuando el jugador termine de caer.
                character.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                character.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

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
