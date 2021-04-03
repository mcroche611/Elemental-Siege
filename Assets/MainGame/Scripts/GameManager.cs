using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*Para hablar con el GameManager basta referenciarlo en alguno de nuestros scripts de esta forma
     GameManager.GetInstance ().NombreMétodoPúblico ();*/


    private static GameManager instance;

    [SerializeField] float ataque, bonoAgua, bonoFuego, bonoElectricidad;

    Transform playerTf;

    void Awake()
    {
        //Si no hay ninguna instancia creada almacenamos aqui la instancia actual
        if (instance == null)
        {
            instance = this;
            //Nos aseguramos de que el objeto al que esta asociado este script no se destruira al cambiar de escena
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Si ya existe un gameobject con un componente instancia de esta clase (es decir ya hay un GM) no necesitamos uno nuevo
            Destroy(this.gameObject);
        }          
    }

    public static GameManager GetInstance() //Para conseguir la referencia a game maager haciendo gameManager.getInstance()
    {
        return instance;
    }

    public float Stat (string nombre)
    {
        if (nombre == "Fuego") return bonoFuego;
        else if (nombre == "Agua") return bonoAgua;
        else if (nombre == "Electricidad") return bonoElectricidad;
        else return ataque;
    }

    public void SetPlayerTransform(Transform tf)
    {
        playerTf = tf;

        if (playerTf != null)
            Debug.Log("PlayerTf correct");
        else
            Debug.Log("PlayerTf null");
    }

    public Transform GetPlayerTransform()
    {
        return playerTf;
    }
}
