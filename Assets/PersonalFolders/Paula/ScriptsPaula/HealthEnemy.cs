using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField]
    private int healthMax;
    private float healthRes;
    [SerializeField]
    private int damageQuemado;
    Quemado estadoQuemado;
    void Start()
    {
        healthRes = healthMax;
        estadoQuemado = GetComponent<Quemado>();
    }

    
    void Update()
    {

        if (healthRes > 0 && (estadoQuemado.enabled == true)) //IMPORTANTE asegurarse de que está en estado quemado
        {
            healthRes -= damageQuemado * Time.deltaTime;
            //Debug.Log(healthRes);
        }

        else if (healthRes < 0) Destroy(this.gameObject); //Si no le queda vida, destruir el enemigo
    }
    
}
