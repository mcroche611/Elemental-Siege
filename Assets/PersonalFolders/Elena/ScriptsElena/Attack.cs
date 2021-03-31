using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //hacemos una variable de cooldown visible desde el editor de momento. Pasar a privado después
    public int cooldown = 2;
    public GameObject espada;
    public float alcance = 1.5f;
    void Start()
    {


    }
    void Update()
    {
        
        Vector3 mousePosition = Input.mousePosition;
        //mousePosition.z = Camera.main.nearClipPlane; //z tiene que ser positivo o puede ocasionar problemas por no estar en campo visible. Empieza a dar la coordenada de la cámara si no. pedes poner z = 10 y tambien
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition); //Transforms a point from screen space into world space, where world space is defined as the coordinate system at the very top of your game's hierarchy.
                                                                                    //es para sacar las coordenadas que tendría desde el punto de vista del jugador de la cámara

        Vector3 mouseDir = (mouseWorldPosition - transform.position).normalized;
        mouseDir.z = 0;
        Vector3 swordPosition = new Vector3();

        swordPosition = mouseDir*alcance + transform.position;
        
        if (Input.GetMouseButtonDown(0) && cooldown >=2)
        {
            Debug.Log("sword" + swordPosition + "mouse" + mouseDir + "transform" + transform.position);
            Instantiate<GameObject>(espada, swordPosition, Quaternion.AngleAxis(20, Vector3.forward)); //lo que hace el quaternion es girar 20 grados el axis z
        }
    }
    //idea hacer que vaya al punto donde clickee el ratón y luego eliminarlo al poco


}
