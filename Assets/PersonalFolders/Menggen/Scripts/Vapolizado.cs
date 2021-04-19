using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vapolizado : MonoBehaviour
{
    //Declarar las variables
    [SerializeField] float escaladoDeDanyoFuerte, escaladoDeDanyoDebil;
    float ataque, bonoAgua, bonoFuego, bonoElectricidad;

    private void Start()
    {
        //Cacheamos los GM necesarios
        ataque = GameManager.GetInstance().Stat("");
        bonoAgua = GameManager.GetInstance().Stat("Agua");
        bonoFuego = GameManager.GetInstance().Stat("Fuego");
        bonoElectricidad = GameManager.GetInstance().Stat("Electricidad");
    }
    //Metodo para la vapolización Debil
    public void Vapolizado_Debil()
    {
        GetComponent<EnemyHealth>().QuitarVida(Formula(escaladoDeDanyoDebil));
    }
    //Método para la vapolización Fuego
    public void Vapolizado_Fuerte()
    {
        GetComponent<EnemyHealth>().QuitarVida(Formula(escaladoDeDanyoFuerte));
    }
    //Formula que calcula el daño
    private float Formula(float escalado)
    {
        return (ataque + bonoAgua + bonoFuego) * escalado;
    }
}
