using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEnemies : MonoBehaviour
{
    [SerializeField] 
    GameObject objetoSpawnerF; //Objeto que spawnea enemigos fuertes
    [SerializeField]
    GameObject objetoSpawnerD;  //Objeto que spawnea enemigos debiles
    [SerializeField]
    float vidaMinima;

    EnemyHealth vida;
    void Start()
    {
        //Consigue la vida del enemigo y comprueba si es menor a un determinado valor para ver si debe llamar a enemigos fuertes
        //componenteVida = GetComponent<IblisHealth>(); 
        vida = GetComponent<EnemyHealth>();
    }
    void Update()
    {
         if (vida.Health() < vidaMinima) //Esto probablmente se puede hacer mejor.
         {
             ActivaSpawnerF();
         }
        else
        {
            DesactivaSpawnerF();
        }
        /*if (Input.GetKeyDown("space"))
        {
            ActivaSpawnerF();
        }*/
        /*if (Input.GetKeyDown(KeyCode.M))
        {
            //DesactivaSpawnerD();
            DesactivaSpawnerF();
        }*/
    }
    void ActivaSpawnerD()
    {
        objetoSpawnerD.SetActive(true);
    }
    void DesactivaSpawnerD()
    {
        if (objetoSpawnerD != null)
        {
            objetoSpawnerD.SetActive(false);
        }  
    }
    void ActivaSpawnerF()
    {
        objetoSpawnerF.SetActive(true);
    }
    void DesactivaSpawnerF()
    {
        if (objetoSpawnerD != null)
        {
           objetoSpawnerF.SetActive(false);
        }
    }
    private void OnDestroy() 
    {
        DesactivaSpawnerD();
        DesactivaSpawnerF();
    }
    
}
