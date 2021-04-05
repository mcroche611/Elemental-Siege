using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mojado : MonoBehaviour
{
    public GameObject icono;
    EnemyRaycast enemyRaycast;

    [SerializeField]
    float disminucionVelocidad;

    private void Awake()
    {
        enemyRaycast = GetComponent<EnemyRaycast>(); //tomamos el script enemyRange porque es el que contiene la velocidad de movimiento del enemigo

    }
    private void OnEnable()
    {
        //Debug.Log("Estado actual del enemigo: Mojado");
        Instantiate<GameObject>(icono, new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2 + 0.5f, transform.position.z), icono.transform.rotation, transform);
        enemyRaycast.disminuirVelocidad(disminucionVelocidad); //al activarse disminuye la velocidad
    }

    private void OnDisable()
    {
        //Debug.Log("Estado actual del enemigo: Ninguno");
        Destroy(transform.GetChild(0).gameObject);
        enemyRaycast.restablecerVelocidad(disminucionVelocidad); //vuelve a moverse a la misma velocidad que al principio

    }
}
