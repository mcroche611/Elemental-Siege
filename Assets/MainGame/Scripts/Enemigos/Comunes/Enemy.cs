using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool estaMuerto = false;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager levelManager = LevelManager.GetInstance();
        //si es un pasillo
        if (levelManager.TipoHabitacion() == 'P')
        {
            //si el jugador no ha pisado la escena antes
            if (!levelManager.HabiaEntradoAntes())
                //se guarda en el registro de los pasillos          
                levelManager.NuevoEnemigo(gameObject.name);
            //si ya la ha pisado
            else
            {
                //el GM se encarga de reestablecer sus valores de antes de salir 
                //tambien comprueba si el enemigo estaba muerto y en caso afirmativo
                //modifica la variable esta muerto antes de destruirlo para evitar problemas
                levelManager.IniEnemigo(this.gameObject);
            }
        }
        //si es una sala
        else
        {
            estaMuerto = true;
            //que ya está completa
            if (levelManager.HabiaEntradoAntes())
            {
                //destruyo el objeto               
                Destroy(this.gameObject);
            }
            //si no 
            else
            {
                //añado el enemigo al registro para bloquear puertas
                levelManager.AñadirEnemigoEnSala();
            }
        }    
    }

    private void OnDestroy()
    {
        if (!estaMuerto)      
            LevelManager.GetInstance().ModificarEnemigo(this.gameObject, GetComponent<EnemyHealth>().Health());      
    }

    public void EstaMuerto()
    {
        estaMuerto = true;
    }
}
