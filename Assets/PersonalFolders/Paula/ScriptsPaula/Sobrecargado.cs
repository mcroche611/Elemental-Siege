using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sobrecargado : MonoBehaviour
{
    public GameObject areaEfecto;

    [SerializeField] float escaladoDeDaño; //0.6 para esta reaccion
    float ataque, bonoAgua, bonoFuego, bonoElectricidad;

    private void Start()
    {
        ataque = GameManager.GetInstance().Stat("");
        bonoAgua = GameManager.GetInstance().Stat("Agua");
        bonoFuego = GameManager.GetInstance().Stat("Fuego");
        bonoElectricidad = GameManager.GetInstance().Stat("Electricidad");
    }

    public void Sobrecarga()
    {
        Instantiate<GameObject>(areaEfecto, transform.position, transform.rotation);
        GetComponent<EnemyHealth>().QuitarVida(Formula());
        
    }

    private float Formula()
    {
        return (ataque + bonoFuego + bonoElectricidad) * escaladoDeDaño;
    }

}
