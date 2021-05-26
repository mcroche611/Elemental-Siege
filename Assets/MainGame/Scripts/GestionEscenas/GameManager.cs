using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private UIManager theUIManager;

    [SerializeField] float ataque, bonoAgua, bonoFuego, bonoElectricidad, valorIniBono;

    GameObject player;
    GameObject pauseMenu;

    public void SetUIManager(UIManager uim)
    {
        theUIManager = uim;
    }

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

    public static GameManager GetInstance() //Para conseguir la referencia a game manager haciendo GameManager.GetInstance()
    {
        return instance;
    }

    public float Stat(string nombre)
    {
        if (nombre == "Fuego") return bonoFuego;
        else if (nombre == "Agua") return bonoAgua;
        else if (nombre == "Electricidad") return bonoElectricidad;
        else return ataque;
    }

    public void SetPlayer(GameObject playerGO)
    {
        if (playerGO == null)
            Debug.LogError("playerGO null");
        else
            this.player = playerGO;
    }

    public GameObject GetPlayer()
    {
        if (player != null)
            return player;
        else
            return null;
    }

    public Transform GetPlayerTransform()
    {
        if (player != null)
            return player.transform;
        else
            return null;
    }

    public void SetPauseMenu(GameObject pauseMenuGO)
    {
        pauseMenu = pauseMenuGO;
    }

    public void DestroyPauseMenu()
    {
        Destroy(pauseMenu);
    }

    //Actualización UI 
    public void GMActualizarVida(float porcentajeVida)
    {
        theUIManager.ActualizarVida(porcentajeVida);
    }

    public void GMActualizarMana(float porcentajeMana)
    {
        theUIManager.ActualizarMana(porcentajeMana);
    }

    public void GMActualizarElementos(string elemento)
    {
        theUIManager.ActualizarElementos(elemento);
    }

    public void GMDestruirCanvas()
    {
        theUIManager.DestruirCanvas();
    }

    public void GMOcultarMostrarCanvas(bool b)
    {
        theUIManager.OcultarMostrarCanvas(b);
    }

    public void AumentarBono(string elemento, float cantidad)
    {
        if (elemento == "Agua") 
            bonoAgua += cantidad;
        else if (elemento == "Fuego") 
            bonoFuego += cantidad;
        else if (elemento == "Electricidad") 
            bonoElectricidad += cantidad;
    }

    public void ResetBonos()
    {
        bonoAgua = valorIniBono;
        bonoFuego = valorIniBono;
        bonoElectricidad = valorIniBono;
    }
}
