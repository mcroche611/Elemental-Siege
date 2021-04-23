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
        Invoke("Spawn", 0f);
        
        
    }
    private void OnDisable()
    {
        CancelInvoke("Spawn");
    }
    public void Debiles()
    {
        fuertes = false;
    }
    void Spawn()
    {
        
        
        //Vector2 desp=new Vector2()
        for (int i = 0; i < 3; i++)
        {
            /*int rndPosX = Random.Range(0, 2);
            int rndPosY = Random.Range(1, 2);
            Vector2 desp = new Vector2(rndPosX, rndPosY);*/
            if (posIni < enemigosDebiles.Length)
            {
                Instantiate<GameObject>(enemigosDebiles[posIni], posiciones[i].position, transform.rotation);
                posIni++;
            }
            else
            { 
                posIni = 0;
                Instantiate<GameObject>(enemigosDebiles[posIni], posiciones[i].position, transform.rotation);
            }
            Debug.Log("posIni:" + posIni);
        }
        //Instantiate<GameObject>(enemigosDebiles[posIni], transform.position, transform.rotation);
    }
}
