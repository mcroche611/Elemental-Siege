using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrocutado : MonoBehaviour
{
    GameObject icono;

    private void Awake()
    {
        icono = (transform.GetChild(1).gameObject).transform.GetChild(2).gameObject; 
    }

    private void OnEnable()
    {
        icono.SetActive(true);      
        GetComponent<Paralizar>().Paraliza();
    }

    private void OnDisable()
    {
        icono.SetActive(false);
    }




}
