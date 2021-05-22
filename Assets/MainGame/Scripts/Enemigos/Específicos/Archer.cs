using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    public GameObject prefabFlecha;
    Transform posPlayer;

    [SerializeField]
    float attackCoolDown = 1f;

    [HideInInspector] public bool paralizado = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        posPlayer = collision.GetComponent<Transform>();
        Invoke("ShootArrow", attackCoolDown / 3);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke("ShootArrow");
    }

    public void ShootArrow()
    {
        if (!paralizado)
        {
            SoundManager.GetInstance().archerShootSound();
            float angulo = Mathf.Atan2(posPlayer.position.y - transform.position.y, posPlayer.position.x - transform.position.x) * 180 / Mathf.PI;
            Quaternion anguloQuaternion = Quaternion.Euler(new Vector3(0f, 0f, angulo - 90)); //sacamos el angulo en el que hay que disparar 
            Instantiate<GameObject>(prefabFlecha, transform.position, anguloQuaternion); //instanciamos la flecha
            Invoke("ShootArrow", attackCoolDown);
        }
        else
            Invoke("ShootArrow", Time.deltaTime);
    }
}
