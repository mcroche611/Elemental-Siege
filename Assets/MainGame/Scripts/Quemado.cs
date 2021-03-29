using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quemado : MonoBehaviour
{
    public GameObject icono;

    private void OnEnable()
    {
        Debug.Log("Estado actual del enemigo: Quemado");
        Instantiate<GameObject>(icono, new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2 + 0.5f, transform.position.z), icono.transform.rotation, transform);
    }

    private void OnDisable()
    {
        Debug.Log("Estado actual del enemigo: Ninguno");
        Destroy(transform.GetChild(0).gameObject);
    }
}
