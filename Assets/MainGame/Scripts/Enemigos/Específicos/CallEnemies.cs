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
    EnemyHealth prueba;
    void Start()
    {
        //Consigue la vida del enemigo y comprueba si es menor a un determinado valor para ver si debe llamar a enemigos fuertes
        //componenteVida = GetComponent<IblisHealth>(); 
        prueba = GetComponent<EnemyHealth>();
    }

    void Update()
    {
         if (prueba.Health() < vidaMinima) //Esto probablmente se puede hacer mejor.
         {
            SoundManager.GetInstance().llamarSoldadosSound();
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
