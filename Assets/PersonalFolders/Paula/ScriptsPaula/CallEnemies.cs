using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEnemies : MonoBehaviour
{
    [SerializeField] 
    GameObject objetoSpawnerF;
    [SerializeField]
    GameObject objetoSpawnerD;
    [SerializeField]
    float vidaMinima;
    //IblisHealth componenteVida;

    void Start()
    {
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
          
            //ActivaSpawnerD();
            ActivaSpawnerF();

        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            //DesactivaSpawnerD();
            DesactivaSpawnerF();
        }
    }
    void ActivaSpawnerD()
    {
        objetoSpawnerD.SetActive(true);
    }
    void DesactivaSpawnerD()
    {
        objetoSpawnerD.SetActive(false);
    }

    void ActivaSpawnerF()
    {
        objetoSpawnerF.SetActive(true);
    }
    void DesactivaSpawnerF()
    {
        objetoSpawnerF.SetActive(false);
    }

    private void OnDestroy() //destruir spawner cuando se destruya a iblis
    {
        Destroy(objetoSpawnerD);
        Destroy(objetoSpawnerF);
    }

}
