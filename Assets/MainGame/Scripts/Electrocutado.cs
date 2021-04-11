using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrocutado : MonoBehaviour
{
    public GameObject icono;
    [SerializeField] float tiempoParalización;

    private void OnEnable()
    {
        //Debug.Log("Estado actual del enemigo: Electrocutado");
        Instantiate<GameObject>(icono, new Vector3(transform.position.x, transform.position.y + transform.localScale.y/2 + 0.5f, transform.position.z), icono.transform.rotation, transform);
        GetComponent<Paralizar>().Paraliza();
    }

    private void OnDisable()
    {
        //Debug.Log("Estado actual del enemigo: Ninguno");
        Destroy(transform.GetChild(1).gameObject);
    }




}
