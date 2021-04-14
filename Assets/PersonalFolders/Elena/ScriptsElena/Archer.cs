using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    [SerializeField]
    GameObject prefabFlecha;

    [SerializeField]

    float cooldown = 1f;
    Transform playerTransform; //def del transform del player para usarlo

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            playerTransform = collision.transform;
            //ShootArrow();
            InvokeRepeating("ShootArrow", 0f, cooldown);
        }

    }

    void ShootArrow()
    {
        float angulo = Mathf.Atan2(playerTransform.position.y - transform.position.y, playerTransform.transform.position.x - transform.position.x) * 180 / Mathf.PI;
        Quaternion anguloQuaternion = Quaternion.Euler(new Vector3(0f, 0f, angulo - 90)); //sacamos el angulo en el que hay que disparar 
        Instantiate<GameObject>(prefabFlecha, transform.position, anguloQuaternion); //instanciamos la flecha

    }


}
