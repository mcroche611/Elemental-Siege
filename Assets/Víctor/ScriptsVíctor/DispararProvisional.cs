using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararProvisional : MonoBehaviour
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
        if (cont <= 0)
        {
            if (Input.GetKey("q"))
            {
                Instantiate<GameObject>(fuego, transform.position, fuego.transform.rotation);
                cont = 2;
            }
            else if (Input.GetKey("w"))
            {
                Instantiate<GameObject>(agua, transform.position, fuego.transform.rotation);
                cont = 2;
            }
            else if (Input.GetKey("e"))
            {
                Instantiate<GameObject>(electricidad, transform.position, fuego.transform.rotation);
                cont = 2;
            }
        }       
        cont -= Time.deltaTime;
    }
}
