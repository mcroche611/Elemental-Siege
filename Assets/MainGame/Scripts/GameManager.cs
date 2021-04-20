using System.Collections;
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
    GameObject Nasnas;
    Vector2 puertaNorte, puertaSur, puertaEste, puertaOeste;
    string orientacion;

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
        Nasnas = (GameObject) Instantiate(Player, Player.transform.position, Player.transform.rotation);
        nivel = Nivel1();      
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

    public void Puerta(string _orientacion)
    {
        orientacion = _orientacion;

        if (_orientacion == "Este") nivel.sceneNow.y++;
        else if (_orientacion == "Norte") nivel.sceneNow.x--;
        else if (_orientacion == "Sur") nivel.sceneNow.x++;
        else nivel.sceneNow.y--;

        SceneManager.LoadScene(nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y]);       
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
                if (S != "---" && S != "1M")
                    s.enemies[i, j] = true;
                else
                    s.enemies[i, j] = false;
            }
        }

        s.sceneNow.x = 4;
        s.sceneNow.y = 0;

        return s;
    }

    private void OnLevelWasLoaded()
    {      
        if (orientacion == "Este") Nasnas.transform.position = GameObject.Find("Puerta Oeste").transform.position + new Vector3(2f, 0, 0);
        else if (orientacion == "Norte") Nasnas.transform.position = GameObject.Find("Puerta Sur").transform.position + new Vector3(0, 2f, 0);
        else if (orientacion == "Sur") Nasnas.transform.position = GameObject.Find("Puerta Norte").transform.position  + new Vector3(0, -2f, 0);
        else if (orientacion == "Oeste") Nasnas.transform.position = GameObject.Find("Puerta Este").transform.position + new Vector3(-2f, 0, 0);              
    }

    /*
    public void IniPuertas(string orientacion, Vector2 posicion)
    {
        if (orientacion == "Este") puertaEste = posicion;
        else if (orientacion == "Norte") puertaNorte = posicion;
        else if (orientacion == "Sur") puertaSur = posicion;
        else puertaOeste = posicion;
    }
    */
}
