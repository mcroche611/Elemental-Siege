using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    string orientacion;
    bool puedeEntrar = false;

    private void Start()
    {
        orientacion = gameObject.name.Split(' ')[1];
        Invoke("PuedeEntrar", 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Health>() && puedeEntrar)
        {
            LevelManager levelManager = LevelManager.GetInstance();

            if (levelManager.TipoHabitacion() == 'P')
            {
                levelManager.CompletarHabitacion();
                levelManager.Puerta(orientacion);
            }
            else if (levelManager.TipoHabitacion() == 'S')
            {
                if (levelManager.SalaCompletada())
                {
                    levelManager.CompletarHabitacion();
                    levelManager.Puerta(orientacion);
                }
                else
                    Debug.Log("Tienes que matar a todos los enemigos para salir de la sala");
            }
            else if (levelManager.TipoHabitacion() == 'M')
                levelManager.Puerta(orientacion);
        }
            
        else if (collision.GetComponent<MagoEncerrado>())
            Destroy(collision.gameObject);
    }

    void PuedeEntrar()
    {
        puedeEntrar = true;
    }
}
