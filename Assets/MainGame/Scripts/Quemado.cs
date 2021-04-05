using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quemado : MonoBehaviour
{
    public GameObject icono;
    [SerializeField] float dañoQuemadura;
    [SerializeField] float timpoQuemadura;
    EnemyHealth enemy;

    private void Awake()
    {
        enemy = GetComponent<EnemyHealth>();
    }

    private void OnEnable()
    {
        //Debug.Log("Estado actual del enemigo: Quemado");
        Instantiate<GameObject>(icono, new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2 + 0.5f, transform.position.z), icono.transform.rotation, transform);
        InvokeRepeating("Quemar", 0f, timpoQuemadura);
    }

    private void OnDisable()
    {
        //Debug.Log("Estado actual del enemigo: Ninguno");
        CancelInvoke("Quemar");
        Destroy(transform.GetChild(0).gameObject);
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
