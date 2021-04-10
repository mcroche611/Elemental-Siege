using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electrocargado : MonoBehaviour
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

    public void Electrocargado_()
    {
        GetComponent<EnemyHealth>().QuitarVida(Formula());
        Instantiate<GameObject>(areaEfecto, transform.position, transform.rotation);
    }

    private float Formula()
    {
        return (ataque + bonoAgua + bonoFuego) * escaladoDeDaño;
    }
}
