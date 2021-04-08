using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemigo;
    [SerializeField] float tiempoSpawn;

    private void Start()
    {
        InvokeRepeating("Spawn", 0f, tiempoSpawn);
    }

    private void Spawn()
    {
        Instantiate<GameObject>(enemigo, transform.position, enemigo.transform.rotation);
    }
}
