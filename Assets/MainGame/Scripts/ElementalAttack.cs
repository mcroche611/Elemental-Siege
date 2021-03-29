using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalAttack : MonoBehaviour
{
    //Variables accesibles desde el editor
    public GameObject fuego, agua, electricidad;
    float cont = 0;
    Mana quitaMana;
    [SerializeField]
    int manaAgua;
    [SerializeField]
    int manaFuego;
    [SerializeField]
    int manaElectro;

   
    private void Start()
    {
        quitaMana = GetComponent<Mana>();
    }


    private void Update()
    {
        if (cont <= 0 && Input.GetButton("Jump"))
        {
            string elementoActual = GetComponent<ElementChanger>().ElementoActual();
<<<<<<< HEAD
            if (elementoActual == "Fuego")
                Instantiate<GameObject>(fuego, transform.position, fuego.transform.rotation);
            else if (elementoActual == "Electricidad")
=======

            if (elementoActual == "Fuego" && quitaMana.RestaMana(manaFuego))
                Instantiate<GameObject>(fuego, transform.position, fuego.transform.rotation);
            else if (elementoActual == "Electricidad" && quitaMana.RestaMana(manaElectro))
>>>>>>> 009fc488c6d0da76c09fbd8b325eb396592fc5b7
                Instantiate<GameObject>(electricidad, transform.position, fuego.transform.rotation);
            else if (quitaMana.RestaMana(manaAgua))
                Instantiate<GameObject>(agua, transform.position, fuego.transform.rotation);
            cont = 0.5f;
        }       
        cont -= Time.deltaTime;
    }
}
