using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //hacemos una variable de cooldown visible desde el editor de momento. Pasar a privado después
    public float cooldown = 2;
    float cooldownSecs = 2;
    public GameObject espada;
    void Awake()
    {


    }
    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0) && cooldown <= 0)
        {
            GetComponent<PlayerController>().enabled = false;
            Atacar();
            Invoke("Habilitar", cooldownSecs);  //se vuelve a habilitar pasado el cooldown
            cooldown = cooldownSecs;
        }

    }
    private Quaternion Rotation()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 vector = new Vector2(mouseWorldPosition.x - transform.position.x, mouseWorldPosition.y - transform.position.y);
        float angulo = Mathf.Atan2(vector.y, vector.x) * 180 / Mathf.PI;
        return Quaternion.Euler(new Vector3(0f, 0f, angulo-90));
    }

    private void Atacar()
    {
        Instantiate<GameObject>(espada, transform.position, Rotation(), transform);

    }

    private void Habilitar()
    {
        GetComponent<PlayerController>().enabled = true;
    }

}


//para hacer que le quite vida a los enemigos se me ocurre lo siguiente
/*
 * poner en el script de enemy o en alguno que lleve el enemigo o incluso en el de la espada para acceder a él y poner ahi el atributo de ataque
 * enemy = GetComponent<Enemy>();
 * enemy.QuitarVida(ataque)
 * espero que se pueda hacer, preguntar ^^
 * 
 * 
 * 
 * 
 * 
 */