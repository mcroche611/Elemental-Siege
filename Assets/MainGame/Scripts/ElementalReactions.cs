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
        GetComponent<EnemyHealth>().QuitarVida(Formula(bonoAgua, bonoElectricidad, escaladoDeDañoElectrocargado));
        Instantiate<GameObject>(areaEfectoElectrocaragado, transform.position, transform.rotation);
    }

    public void Sobrecargado()
    {
        Instantiate<GameObject>(areaEfectoSobrecargado, transform.position, transform.rotation, transform);
        GetComponent<EnemyHealth>().QuitarVida(Formula(bonoFuego, bonoElectricidad, escaladoDeDañoSobrecargado));

        GetComponentInChildren<AEOSobrecargado>().EnemigoGolpeado(this.gameObject);
        GetComponent<EnemyMovement>().enabled = false;
        Rigidbody2D rbEnemy = GetComponent<Rigidbody2D>();
        rbEnemy.AddForce(direccionBola.normalized * GetComponentInChildren<AEOSobrecargado>().knock, ForceMode2D.Impulse);
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
