using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementChanger : MonoBehaviour
{
    [SerializeField] float coolDown;

    float cont = 0;
    string[] elementos = new string[3] { "Agua", "Fuego",  "Electricidad" };
    int elementoActual = 1;
    
    void Update()
    {
        float input = Input.GetAxis("Elementos");
        float input2 = Input.GetAxis("Mouse ScrollWheel");

        if (cont <= 0 && (input != 0 || input2 != 0))
        {
            if (input > 0 || input2 > 0)
                elementoActual = (elementoActual + 1) % 3;
            else elementoActual = (elementoActual + 2) % 3;
            Debug.Log("Elemento seleccionado: " + elementos[elementoActual]);
            GameManager.GetInstance().GMActualizarElementos(elementos[elementoActual]);
            cont = coolDown;
        }
        cont -= Time.deltaTime;
    }

    public string ElementoActual() { return elementos[elementoActual]; }
}
