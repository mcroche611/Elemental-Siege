using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;
    
    public void QuitarVida(float cantidad)
    {
        if (GetComponent<EscudoFuego>().enabled == false) //si el enemigo no tiene escudo, se le daña
            health -= cantidad;
        Debug.Log(health);

        if (health <= 0)
        {
            Slime slime = GetComponent<Slime>();
            if (slime != null)
                slime.InstanciarSlimes();
            Destroy(this.gameObject);
        }           
    }   
}
