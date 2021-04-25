using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quemado : MonoBehaviour
{
    [SerializeField] float dañoQuemadura;
    [SerializeField] float tiempoQuemadura;
    EnemyHealth enemy;
    GameObject icono;

    private void Awake()
    {
        enemy = GetComponent<EnemyHealth>();
        icono = (transform.GetChild(1).gameObject).transform.GetChild(0).gameObject;
    }

    private void OnEnable()
    {
        icono.SetActive(true);
        
        InvokeRepeating("Quemar", tiempoQuemadura, tiempoQuemadura);
        
    }

    private void OnDisable()
    {
        CancelInvoke("Quemar");
        icono.SetActive(false);
    }

    private void Quemar()
    {
        enemy.QuitarVida(dañoQuemadura);
    }

    private void OnDestroy()
    {
        CancelInvoke("Quemar");
       
    }
}
