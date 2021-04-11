using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vapolizado : MonoBehaviour
{
    [SerializeField] float escaladoDeDañoFuerte, escaladoDeDañoDebil;
    float ataque, bonoAgua, bonoFuego, bonoElectricidad;

    private void Start()
    {
        ataque = GameManager.GetInstance().Stat("");
        bonoAgua = GameManager.GetInstance().Stat("Agua");
        bonoFuego = GameManager.GetInstance().Stat("Fuego");
        bonoElectricidad = GameManager.GetInstance().Stat("Electricidad");
    }
    public void Vapolizado_Debil()
    {
        GetComponent<EnemyHealth>().QuitarVida(Formula(escaladoDeDañoDebil));
    }
    public void Vapolizado_Fuerte()
    {
        GetComponent<EnemyHealth>().QuitarVida(Formula(escaladoDeDañoFuerte));
    }

    private float Formula(float escalado)
    {
        return (ataque + bonoAgua + bonoFuego) * escalado;
    }
}
