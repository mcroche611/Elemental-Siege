using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalReactions : MonoBehaviour
{
    public GameObject areaEfectoElectrocaragado, areaEfectoSobrecargado;

    [SerializeField] float escaladoDeDañoElectrocargado, escaladoDeDañoSobrecargado, escaladoDeDañoVaporizadoDebil, escaladoDeDañoVaporizadoFuerte;
    float ataque, bonoAgua, bonoFuego, bonoElectricidad;

    Vector2 direccionBola;

    private void Start()
    {
        ataque = GameManager.GetInstance().Stat("");
        bonoAgua = GameManager.GetInstance().Stat("Agua");
        bonoFuego = GameManager.GetInstance().Stat("Fuego");
        bonoElectricidad = GameManager.GetInstance().Stat("Electricidad");
    }

    public void Electrocargado()
    {
        Instantiate<GameObject>(areaEfectoElectrocaragado, transform.position, transform.rotation);
        GetComponent<EnemyHealth>().QuitarVida(Formula(bonoAgua, bonoElectricidad, escaladoDeDañoElectrocargado));
    }

    public void Sobrecargado()
    {
        GameObject _areaEfectoSobrecargado = (GameObject) Instantiate(areaEfectoSobrecargado, transform.position, transform.rotation);
        AEOSobrecargado explosion = _areaEfectoSobrecargado.GetComponent<AEOSobrecargado>();   
        
        float damage = Formula(bonoFuego, bonoElectricidad, escaladoDeDañoSobrecargado);
        explosion.Damage(damage);
        explosion.EnemigoGolpeado(this.gameObject);
        
        GetComponent<EnemyHealth>().QuitarVida(damage);

        
        EnemyMovement enemyMovement = GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            explosion.GetComponent<AEOSobrecargado>().Knockback(out float knock, out float tiempoAturdimiento);
            GetComponent<EnemyMovement>().Knockback(tiempoAturdimiento);
            GetComponent<Rigidbody2D>().AddForce(direccionBola.normalized * knock, ForceMode2D.Impulse);
        }
                  
    }

    public void VapolizadoDebil()
    {
        GetComponent<EnemyHealth>().QuitarVida(Formula(bonoAgua, bonoFuego, escaladoDeDañoVaporizadoDebil));
    }

    public void VapolizadoFuerte()
    {
        GetComponent<EnemyHealth>().QuitarVida(Formula(bonoFuego, bonoAgua, escaladoDeDañoVaporizadoFuerte));
    }

    private float Formula(float elementoEstado, float elementoReaccionante, float escaladoDeDaño)
    {
        return (ataque + elementoEstado + elementoReaccionante) * escaladoDeDaño;
    }

    public void RotacionBola(Vector2 rotacion)
    {
        direccionBola = rotacion;
    }
}
