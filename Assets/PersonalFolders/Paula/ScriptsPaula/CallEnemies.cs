using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEnemies : MonoBehaviour
{
    [SerializeField] GameObject objetoSpawner;
    Spawner scriptSpawner;
    void Start()
    {
        //scriptSpawner = objetoSpawner.gameObject.GetComponent<Spawner>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            objetoSpawner.SetActive(true);
        }
        else
        {
            objetoSpawner.SetActive(false);
        }
    }
    private void OnDestroy() //destruir spawner cuando se destruya a iblis
    {
        Destroy(objetoSpawner);
    }
}
