using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] 
    GameObject [] enemigosFuertes;
    [SerializeField]
    GameObject[] enemigosDebiles;
    [SerializeField]
    Transform[] posiciones;
    float tiempoSpawn;
    bool fuertes;
    int posIni;

    private void OnEnable()
    {
        Invoke("SpawnFuertes", 0f);
        
        
    }
    private void OnDisable()
    {
        CancelInvoke("SpawnFuertes");
    }
    public void Debiles()
    {
        fuertes = false;
    }
    void SpawnFuertes()
    {
       
        //Vector2 desp=new Vector2()
        for (int i = 0; i < 3; i++)
        {
            
            /*int rndPosX = Random.Range(0, 2);
            int rndPosY = Random.Range(1, 2);
            Vector2 desp = new Vector2(rndPosX, rndPosY);*/
            if (posIni < enemigosFuertes.Length)
            {
                Instantiate<GameObject>(enemigosFuertes[posIni], posiciones[i].position, posiciones[i].rotation);
                posIni++;
            }
            else
            { 
                posIni = 0;
                Instantiate<GameObject>(enemigosFuertes[posIni], posiciones[i].position, posiciones[i].rotation);
            }
            Debug.Log("posIni:" + posIni);
        }
        
    }
}
