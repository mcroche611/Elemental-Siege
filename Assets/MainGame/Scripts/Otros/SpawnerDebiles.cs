using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDebiles : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemigosDebiles;
    [SerializeField]
    Transform[] posiciones;
    [SerializeField]
    float tiempoSpawn;
    [SerializeField]
    float beforeSpawn;
    int posIniD; //Indice que recorre el array de enemigos debiles

    private void OnEnable()
    {
        //La primera posicion es la 0
        posIniD = 0;
        InvokeRepeating("SpawnDebiles", beforeSpawn, tiempoSpawn); //Se invocan enmigos constantemente hasta que se desactive el GO (con la muerte de Iblis creo)

    }
    private void OnDisable()
    {
        CancelInvoke("SpawnDebiles");
    }
    void SpawnDebiles()
    {
        //se encarga de crear enemigos en una deteminada posicion hija del GO SpawnerDebiles

        Instantiate<GameObject>(enemigosDebiles[posIniD], posiciones[1].position, transform.rotation);
        Debug.Log("Posini: " + posIniD);

        if (posIniD < enemigosDebiles.Length - 1) //controlamos que el indice no se salga de los limites del array
        {
            posIniD++;
        }
        else //si llega al ultimo valor permitido se pone a 0 y vuelve a empezar por asi decirlo
        {
            posIniD = 0;
        }


    }
}
