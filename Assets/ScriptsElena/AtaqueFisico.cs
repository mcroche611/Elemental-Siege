using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueFisico : MonoBehaviour
{
    //hacemos una variable de cooldown visible desde el editor de momento. Pasar a privado después
    public int cooldown = 2;
    public GameObject espada;
    public float alcance = 1.5f;
    

	void Update()
    {
            //conseguimos un vector con la dirección del mouse. Mirar si hay alguno 2D mejor (?)

            //Vector3 mousePosition = new Vector3();
            //Vector3 mouseDir = new Vector3();
            //mousePosition = Input.mousePosition;
            //mouseDir = (mousePosition).normalized;            No funciona bien

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane; //z tiene que ser positivo o puede ocasionar problemas por no estar en campo visible. Empieza a dar la coordenada de la cámara si no. pedes poner z = 10 y tambien
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition); //Transforms a point from screen space into world space, where world space is defined as the coordinate system at the very top of your game's hierarchy.
                                                                                        //es para sacar las coordenadas que tendría desde el punto de vista del jugador de la cámara

            Vector3 mouseDir = (mouseWorldPosition - transform.position).normalized;
            mouseDir.z = 10;
            Vector3 swordPosition = new Vector3();
            //si hago esto de abajo, al final el transform es más grande y a la izquierda sale el vector postivo también
            swordPosition = (mouseDir + transform.position);
            //swordPosition.x = mouseDir.x * transform.position.x;
            //swordPosition.y = mouseDir.y * transform.position.y;
            //swordPosition.z = 10;
            //swordPosition = swordPosition * alcance;

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("sword" + swordPosition + "mouse" + mouseDir + "transform" + transform.position);
                Instantiate<GameObject>(espada, swordPosition, transform.rotation);
            }
        
        //idea hacer que vaya al punto donde clickee el ratón y luego eliminarlo al poco


    }

}
