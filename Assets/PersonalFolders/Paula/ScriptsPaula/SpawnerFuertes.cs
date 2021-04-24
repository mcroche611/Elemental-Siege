using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFuertes : MonoBehaviour
{
    [SerializeField] 
    GameObject [] enemigosFuertes;
    [SerializeField]
    Transform[] posiciones;
    int posIniF; //Indice que recorre el array de enemigos fuertes

    private void OnEnable()
    {
        Invoke("SpawnFuertes", 0f); //Los invoca una vez cuando ocurre una determinada condicion   
    }
    private void OnDisable()
    {
        CancelInvoke("SpawnFuertes");
    }
    void SpawnFuertes()
    {

        /*OJO:si no queremos que se instancien 3 enemigos concretamente hay que exernalizar esta variable y 
         * ademas aumentar o disminuir el numero de GO vacios hijos del spawner*/

        for (int i = 0; i < 3; i++) 
        {
            //crea el enemigo indicado por la posicion del array en uno de los GO hijos del spawner
            Instantiate<GameObject>(enemigosFuertes[posIniF], posiciones[i].position, transform.rotation); 
            if (posIniF < enemigosFuertes.Length-1)
            {
                posIniF++;
            }
            else
            { 
                //si llega al limite del array, vuelve a empezar con el enemigo que hay en laprimera posicion
                posIniF = 0;
            }
            Debug.Log("posIni:" + posIniF);
        }
        
    }
   
}
