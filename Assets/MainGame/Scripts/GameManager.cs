﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    /*Para hablar con el GameManager basta referenciarlo en alguno de nuestros scripts de esta forma
     GameManager.GetInstance ().NombreMétodoPúblico ();*/

    private static GameManager instance;
    private UIManager theUIManager;

    public GameObject Player;
    GameObject nasnas;

    private string orientacionUltimaPuerta;
    bool primeraEscena = true;

    struct Coor
    {
        public int x, y;
    }

    struct Escena
    {
        public string[,] scenes;
        public bool[,] enemies;
        public Coor sceneNow;
    }

    Escena nivel;

    [SerializeField] float ataque, bonoAgua, bonoFuego, bonoElectricidad;

    Transform playerTf;
    GameObject player;

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

    private void Start()
    {
        nivel = Nivel1();
        nasnas = (GameObject) Instantiate(Player, transform.position, transform.rotation);
        LevelManager.GetInstance().SetUpCamera(nasnas.transform);
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

    public void SetPlayer(GameObject playerGO)
    {
        if (playerGO == null)
            Debug.LogError("playerGO null");
        else
            this.player = playerGO;
    }

    public Transform GetPlayerTransform()
    {
        if (player != null)
            return player.transform;
        else
            return null;
    }

    public void GMActualizarVida (float porcentajeVida) { theUIManager.ActualizarVida(porcentajeVida); }
    public void GMActualizarMana (float porcentajeMana) { theUIManager.ActualizarMana(porcentajeMana); }
    public void GMActualizarElementos (string elemento) { theUIManager.ActualizarElementos(elemento);  }

    public void Puerta(string orientacion)
    {
        if (orientacion == "Este")
        {
            nivel.sceneNow.y++;
            orientacionUltimaPuerta = "Oeste";
        } 
        else if (orientacion == "Norte")
        {
            nivel.sceneNow.x--;
            orientacionUltimaPuerta = "Sur";
        }
        else if (orientacion == "Sur")
        {
            nivel.sceneNow.x++;
            orientacionUltimaPuerta = "Norte";
        }
        else
        {
            nivel.sceneNow.y--;
            orientacionUltimaPuerta = "Este";
        } 

        SceneManager.LoadScene(nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y]);       
    }

    private void OnLevelWasLoaded(int level)
    {
        LevelManager.GetInstance().SetUpCamera(nasnas.transform);
        LevelManager.GetInstance().SetUpPlayer(orientacionUltimaPuerta, nasnas.transform);
    }   

    static Escena Nivel1()
    {
        Escena s;

        s.scenes = new string[5, 9]  {{ "---","---", "1ME", "1S5", "1P7", "1S6", "1P8", "1S7", "1P9"},
                                      {"---", "---", "---", "1P5", "---", "1P6", "---", "---", "---"},
                                      {"---", "---", "---", "1S3", "1P4", "1S4", "---", "---", "---"},
                                      {"---", "---", "---", "1P3", "---", "1MF", "---", "---", "---"},
                                      {"1P0", "1S0", "1P1", "1S1", "1P2", "1S2", "1MA", "---", "---"}};

        s.enemies = new bool[5, 9];

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                string S = s.scenes[i, j];
                S = S.Remove(S.Length - 1);
                if (S != "---")
                    s.enemies[i, j] = true;
                else
                    s.enemies[i, j] = false;
            }
        }

        s.sceneNow.x = 4;
        s.sceneNow.y = 0;

        return s;
    }
    
    public void CompletarEscena()
    {
        nivel.enemies[nivel.sceneNow.x, nivel.sceneNow.y] = false;
    }

    public bool EscenaCompleta()
    {
        return nivel.enemies[nivel.sceneNow.x, nivel.sceneNow.y];
    }

    public void AumentarBono(string elemento, float cantidad)
    {
        if (elemento == "Agua") bonoAgua += cantidad;
        else if (elemento == "Fuego") bonoFuego += cantidad;
        else bonoElectricidad += cantidad;
    }
}
