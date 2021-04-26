using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadaGuard : MonoBehaviour
{

    [SerializeField]
    float attackCooldown = 2f;
    [SerializeField]
    float attackDamage = 15f;
    [SerializeField]
    float attackDuration = 1f; //cuidado con esto para que no salga negativo

    float cooldown;
    Transform playerTransform;
    GameObject guardSword;

    private void Start()
    {
        guardSword = transform.GetChild(0).gameObject;
        guardSword.transform.position = transform.position;

    }

    private void Update()
    {
        cooldown -= Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerTransform = collision.transform;

        
        Invoke("SwordActivate", 1f);
        guardSword.transform.rotation = Rotation();
        Debug.Log("attack");
        //Invoke("SwordDeactivate", attackDuration);


    }

    private void OnTriggerExit2D(Collider2D other) //al salir el jugador, ya no dispara flechas
    {
        Invoke("SwordDeactivate", 0f);

    }

    private void SwordActivate()
    {
        if (cooldown <= 0)
        {
            guardSword.SetActive(true);
            cooldown = attackCooldown;
            Invoke("SwordDeactivate", attackDuration);

        }

    }

    private void SwordDeactivate()
    {
        guardSword.SetActive(false);

    }

    private Quaternion Rotation()
    {
        Vector2 vector = new Vector2(playerTransform.position.x - transform.position.x, playerTransform.position.y - transform.position.y);
        float angulo = Mathf.Atan2(vector.y, vector.x) * 180 / Mathf.PI;
        return Quaternion.Euler(new Vector3(0f, 0f, angulo - 90));
    }

}
