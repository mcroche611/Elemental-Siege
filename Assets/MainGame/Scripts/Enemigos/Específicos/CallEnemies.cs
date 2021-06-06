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
       
        vida = GetComponent<EnemyHealth>();
    }
    void Update()
    {
        if (vida.Health() < vidaMinima) 
        {
            ActivaSpawnerF();
        }
        else
        {
            DesactivaSpawnerF();
        }
        
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
