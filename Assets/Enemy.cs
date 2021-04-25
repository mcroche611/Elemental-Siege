using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool estaMuerto = false;
    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = GameManager.GetInstance();

        if (gameManager.juegoPrincipal)
        {
            //si es un pasillo
            if (gameManager.EsPasillo())
            {
                //si el jugador no ha pisado la escena antes
                if (gameManager.EscenaCompleta())
                    //se guarda en el registro de los pasillos          
                    gameManager.NuevoEnemigo(gameObject.name);
                //si ya la ha pisado
                else
                {
                    //el GM se encarga de reestablecer sus valores de antes de salir 
                    //tambien comprueba si el enemigo estaba muerto y en caso afirmativo
                    //modifica la variable esta muerto antes de destruirlo para evitar problemas
                    gameManager.IniEnemigo(this.gameObject);
                }
            }
            //si es una sala
            else
            {
                //que ya está completa
                if (!gameManager.EscenaCompleta())
                {
                    //destruyo el objeto
                    estaMuerto = true;
                    Destroy(this.gameObject);
                }
                //si no 
                else
                {
                    //añado el enemigo al registro para bloquear puertas
                    gameManager.AñadirEnemigoEnSala();
                }
            }
        }
    }

    private void OnDestroy()
    {
        if (GameManager.GetInstance().juegoPrincipal && !estaMuerto)      
            GameManager.GetInstance().ModificarEnemigo(this.gameObject, GetComponent<EnemyHealth>().Health());      
    }

    public void EstaMuerto()
    {
        estaMuerto = true;
    }
}
