using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float health;

    bool escudo;
    public void QuitarVida(float cantidad)
    {
        if (GetComponent<Escudo>() != null) //Si hay escudo se comprueba si está en uso
            escudo = GetComponent<Escudo>().enabled;

        if (GetComponent<Escudo>() == null || !escudo) //si el enemigo no tiene escudo, se le daña
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
