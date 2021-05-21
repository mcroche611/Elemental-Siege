using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject prefabFlecha;

    [SerializeField]
    float attackCoolDown = 1f;

    bool attackEnabled = true;
    [HideInInspector] public bool paralizado = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (attackEnabled && !paralizado)
        {
            ShootArrow(collision.transform.position);
            attackEnabled = false;
            Invoke("EnableAttack", attackCoolDown);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (attackEnabled && !paralizado)
        {
            ShootArrow(collision.transform.position);
            attackEnabled = false;
            Invoke("EnableAttack", attackCoolDown);
        }
    }



    public void ShootArrow(Vector2 posPlayer)
    {
        SoundManager.GetInstance().archerShootSound();
        float angulo = Mathf.Atan2(posPlayer.y - transform.position.y, posPlayer.x - transform.position.x) * 180 / Mathf.PI;
        Quaternion anguloQuaternion = Quaternion.Euler(new Vector3(0f, 0f, angulo - 90)); //sacamos el angulo en el que hay que disparar 
        Instantiate<GameObject>(prefabFlecha, transform.position, anguloQuaternion); //instanciamos la flecha
    }

    private void EnableAttack()
    {
        attackEnabled = true;
    }
}
