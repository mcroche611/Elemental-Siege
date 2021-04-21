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
    float tiempoSpawn;
    bool fuerte = false;

    private void OnEnable()
    {
        if (!fuerte)
        {
            InvokeRepeating("SpawnDebiles", 0f, tiempoSpawn);
        }
        else
        {
            InvokeRepeating("SpawnFuertes", 0f, tiempoSpawn);
        }
        
    }

    private void SpawnFuertes()
    {
        int enemigoRnd=Random.Range(0,enemigosFuertes.Length-1);
        Debug.Log("Crea el enemigo que hay en la posicion: " + enemigoRnd);
        Instantiate<GameObject>(enemigosFuertes[enemigoRnd], transform.position, enemigosFuertes[enemigoRnd].transform.rotation);
    }
    private void SpawnDebiles()
    {
        int enemigoRnd = Random.Range(0, enemigosDebiles.Length - 1);
        Debug.Log("Crea el enemigo que hay en la posicion: " + enemigoRnd);
        Instantiate<GameObject>(enemigosDebiles[enemigoRnd], transform.position, enemigosDebiles[enemigoRnd].transform.rotation);
    }
    private void OnDisable()
    {
        CancelInvoke("SpawnFuertes");
        CancelInvoke("SpawnDebiles");
    }
    public void Fuertes()
    {
        fuerte = true;
    }
}
