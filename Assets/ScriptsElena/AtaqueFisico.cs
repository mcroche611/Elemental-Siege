using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueFisico : MonoBehaviour
{

    //hacemos una variable de cooldown visible desde el editor de momento. Pasar a privado después
    public int cooldown = 2;

    void Start()
    {
        

    }
    void Update()
    {
    //conseguimos un vector con la dirección del mouse. Mirar si hay alguno 2D mejor (?)

        Vector3 mousePosition = new Vector3();
        Vector3 mouseDir = new Vector3();
        Vector3 mouseProbar = new Vector3();
        mouseProbar = 
        mousePosition = Input.mousePosition;
        mouseDir = (mousePosition-transform.position).normalized;
        
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ataque" + mouseDir);
        }
    }


}