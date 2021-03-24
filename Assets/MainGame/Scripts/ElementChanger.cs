using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementChanger : MonoBehaviour
{
    float cont = 0;
    string[] elementos = new string[3] { "Agua", "Fuego",  "Electricidad" };
    int elementoActual = 1;
    

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Elementos");

        if (cont <= 0 && input != 0)
        {
            if (input > 0)
                elementoActual = (elementoActual + 1) % 3;
            else elementoActual = (elementoActual + 2) % 3;
            Debug.Log("Elemento seleccionado: " + elementos[elementoActual]);
            cont = 1;
        }

        cont -= Time.deltaTime;
    }

    public string ElementoActual() { return elementos[elementoActual]; }
}
