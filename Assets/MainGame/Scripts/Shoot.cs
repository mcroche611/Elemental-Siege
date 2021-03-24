using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject fuego, agua, electricidad;
    float cont = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cont <= 0 && Input.GetButton("Jump"))
        {
            string elementoActual = GetComponent<ElementalAtack>().ElementoActual();
            if (elementoActual == "Fuego")
                Instantiate<GameObject>(fuego, transform.position, fuego.transform.rotation);
            else if (elementoActual == "Electricidad")
                Instantiate<GameObject>(electricidad, transform.position, fuego.transform.rotation);
            else
                Instantiate<GameObject>(agua, transform.position, fuego.transform.rotation);
            cont = 0.5f;
        }       
        cont -= Time.deltaTime;
    }
}
