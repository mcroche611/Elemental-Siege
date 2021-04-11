using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vapolizado : MonoBehaviour
{
    [SerializeField] float escaladoDeDaño;
    float ataque, bonoAgua, bonoFuego, bonoElectricidad;

    private void Start()
    {
        ataque = GameManager.GetInstance().Stat("");
        bonoAgua = GameManager.GetInstance().Stat("Agua");
        bonoFuego = GameManager.GetInstance().Stat("Fuego");
        bonoElectricidad = GameManager.GetInstance().Stat("Electricidad");
    }
    public void Vapolizado_()
    {
        GetComponent<EnemyHealth>().QuitarVida(Formula());
    }
    private float Formula()
    {
        return (ataque + bonoAgua + bonoFuego) * escaladoDeDaño;
    }
}
