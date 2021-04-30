using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject [] enemigos;
    [SerializeField] float tiempoSpawn;

    private void OnEnable()
    {
        InvokeRepeating("Spawn", 0f, tiempoSpawn);
    }

    private void Spawn()
    {
        int enemigoRnd=Random.Range(0,enemigos.Length-1);
        Debug.Log("Crea el enemigo que hay en la posicion: " + enemigoRnd);
        Instantiate<GameObject>(enemigos[enemigoRnd], transform.position, enemigos[enemigoRnd].transform.rotation);
    }
    private void OnDisable()
    {
        CancelInvoke("Spawn");
    }
}
