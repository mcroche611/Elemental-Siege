using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mojado : MonoBehaviour
{
    EnemyMovement enemyMovement;
    GameObject icono;

    [SerializeField]
    float disminucionVelocidad;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>(); //tomamos el script enemyRange porque es el que contiene la velocidad de movimiento del enemigo
        icono = (transform.GetChild(1).gameObject).transform.GetChild(1).gameObject;
    }
    private void OnEnable()
    {
        icono.SetActive(true);
        enemyMovement.DisminuirVelocidad(disminucionVelocidad); //al activarse disminuye la velocidad
    }

    private void OnDisable()
    {
        icono.SetActive(false);
        enemyMovement.RestablecerVelocidad(); //vuelve a moverse a la misma velocidad que al principio
    }
}
