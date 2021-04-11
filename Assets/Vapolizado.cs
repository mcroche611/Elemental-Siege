using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vapolizado : MonoBehaviour
{
    public GameObject areaEfecto;

    [SerializeField] float escaladoDeDaño;
    float ataque, bonoAgua, bonoFuego, bonoElectricidad;

    private void Start()
    {
        ataque = GameManager.GetInstance().Stat("");
        bonoAgua = GameManager.GetInstance().Stat("Agua");
        bonoFuego = GameManager.GetInstance().Stat("Fuego");
        bonoElectricidad = GameManager.GetInstance().Stat("Electricidad");
    }

    private float Formula()
    {
        return (ataque + bonoAgua + bonoFuego) * escaladoDeDaño;
        Debug.Log("vapolizado bien hecho");
    }
}
