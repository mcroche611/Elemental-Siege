using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEnemies : MonoBehaviour
{
    [SerializeField] 
    GameObject objetoSpawner;
    [SerializeField]
    float vidaMinima;
    Spawner scriptSpawner;
    IblisHealth componenteVida;

    void Start()
    {
        //Obtiene el coponente spawner para poner la variale de fuerte o debil a true o por u defecto a false
        scriptSpawner = objetoSpawner.GetComponent<Spawner>();
        //Consigue la vida del enemigo y comprueba si es menor a un determinado valor para ver si debe llamar a enemigos fuertes
       // componenteVida = GetComponent<IblisHealth>(); 
       
    }

    void Update()
    {
        /* if (componenteVida.VidaIblis() < vidaMinima) //Esto probablmente se puede hacer mejor.
         {
             scriptSpawner.Fuertes();
             ActivaSpawner();
         }*/
        if (Input.GetKeyDown("space"))
        {
            //scriptSpawner.Debiles();
            ActivaSpawner();
            
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            DesactivaSpawner();
        }
    }
    void ActivaSpawner()
    {
        objetoSpawner.SetActive(true);
    }
    void DesactivaSpawner()
    {
        objetoSpawner.SetActive(false);
    }
    private void OnDestroy() //destruir spawner cuando se destruya a iblis
    {
        Destroy(objetoSpawner);
    }
}
