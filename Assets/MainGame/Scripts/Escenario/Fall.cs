using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    GameObject character;
    float ogScale;
    int i = 0;


    private void FallSize()
    {
        Debug.Log("FallSize: Scale: " + character.transform.localScale.x + " OgScale: " + ogScale + " Fall #: " + i);

        if (character.transform.localScale.x < ogScale / 10)
        {
            Debug.Log("Size reached min");

            if (character.GetComponent<PlayerController>() != null)
            {
                Health charHealth = character.GetComponent<Health>();
                charHealth.DamageOnFall();
            }

            Destroy(character.gameObject);

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
            collision.gameObject.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

            Invoke("FallSize", 0);

            Debug.Log("OgScale: " + ogScale);
        }
    }
}
