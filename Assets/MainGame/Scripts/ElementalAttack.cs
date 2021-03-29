using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalAttack : MonoBehaviour
{
    public GameObject fuego, agua, electricidad;
    float cont = 0;

    void Update()
    {
        if (cont <= 0 && Input.GetButton("Jump"))
        {
            //(Input.mousePosition.x - 8) / 16 - 
            float coorX = Input.mousePosition.x/16 - 24;
            float coorY = Input.mousePosition.y/16 - 15;
            float rotation = Mathf.Atan(coorY / coorX);
            Debug.Log(rotation);
            string elementoActual = GetComponent<ElementChanger>().ElementoActual();
            if (elementoActual == "Fuego")
                Instantiate<GameObject>(fuego, transform.position, new Quaternion(fuego.transform.rotation.x, fuego.transform.rotation.y, rotation, 0f));
            else if (elementoActual == "Electricidad")
                Instantiate<GameObject>(electricidad, transform.position, fuego.transform.rotation);
            else
                Instantiate<GameObject>(agua, transform.position, fuego.transform.rotation);
            cont = 0.5f;
        }       
        cont -= Time.deltaTime;
    }
}
