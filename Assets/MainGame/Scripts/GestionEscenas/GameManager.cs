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
    GameObject nasnas;

    public bool juegoPrincipal;
    private string orientacionUltimaPuerta;
    int enemigosEnSala = 0;

    public string[] scenesInOrder;
    int scene;
    struct Coor
    {
        public int x, y;
    }

    struct Enemigo
    {
        public string nombreEnemigo;
        public Vector2 ultimaPosicion;
        public bool vivo;
        public float vida;
    }

    struct Pasillo
    {
        public Enemigo[] enemigos;
        public int pc;
    }

    struct Escena
    {
        public string[,] scenes;
        public bool[,] enemies;
        public Pasillo[] pasillos;
        public Coor sceneNow;
        public Coor sceneAfter;
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
        nasnas = (GameObject)Instantiate(Player, transform.position, transform.rotation);
        if (juegoPrincipal)
            LevelManager.GetInstance().SetUpCamera(nasnas.transform);
    }

    public static GameManager GetInstance() //Para conseguir la referencia a game maager haciendo gameManager.getInstance()
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

    public Transform GetPlayerTransform()
    {

        if (player != null)
            return player.transform;
        else
            return null;


    }

    public void GMActualizarVida(float porcentajeVida) { theUIManager.ActualizarVida(porcentajeVida); }
    public void GMActualizarMana(float porcentajeMana) { theUIManager.ActualizarMana(porcentajeMana); }
    public void GMActualizarElementos(string elemento) { theUIManager.ActualizarElementos(elemento); }

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
        nivel.sceneAfter.x = nivel.sceneNow.x;
        nivel.sceneAfter.y = nivel.sceneNow.y;
        enemigosEnSala = 0;
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
        int pasillos = 0;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                string S = s.scenes[i, j];
                S = S.Remove(S.Length - 1);
                if (S != "---")
                {
                    s.enemies[i, j] = true;
                    if (S[1] == 'P')
                        pasillos += 1;
                }
                else
                    s.enemies[i, j] = false;
            }
        }

        s.pasillos = new Pasillo[pasillos];

        for (int i = 0; i < s.pasillos.Length; i++)
        {
            s.pasillos[i].enemigos = new Enemigo[50];
            s.pasillos[i].pc = 0;
        }

        s.sceneNow.x = 4;
        s.sceneNow.y = 0;
        s.sceneAfter.x = s.sceneNow.x;
        s.sceneAfter.y = s.sceneNow.y;

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

    public bool EsPasillo() { return nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y][1] == 'P'; }
    public bool EsSala() { return nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y][1] == 'S'; }
    public bool EsMago() { return nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y][1] == 'M'; }

    public bool SalaCompletada() { return enemigosEnSala <= 0; }

    public void NuevoEnemigo(string enemigo)
    {
        int pasilloActual = int.Parse(nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y][2].ToString());

        nivel.pasillos[pasilloActual].enemigos[nivel.pasillos[pasilloActual].pc].nombreEnemigo = enemigo;
        nivel.pasillos[pasilloActual].enemigos[nivel.pasillos[pasilloActual].pc].vivo = true;
        nivel.pasillos[pasilloActual].pc += 1;
    }


    public void IniEnemigo(GameObject enemigo)
    {
        int pasilloActual = int.Parse(nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y][2].ToString());
        int cont = 0;

        while (nivel.pasillos[pasilloActual].enemigos[cont].nombreEnemigo != enemigo.name) cont += 1;

        if (nivel.pasillos[pasilloActual].enemigos[cont].vivo)
        {
            enemigo.transform.position = nivel.pasillos[pasilloActual].enemigos[cont].ultimaPosicion;
            enemigo.GetComponent<EnemyHealth>().EnemigoVidaIni(nivel.pasillos[pasilloActual].enemigos[cont].vida);
        }
        else
        {
            enemigo.GetComponent<Enemy>().EstaMuerto();
            Destroy(enemigo);
        }
    }

    public void MatarEnemigo(GameObject enemigo)
    {
        int pasilloActual = int.Parse(nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y][2].ToString());
        int cont = 0;

        while (nivel.pasillos[pasilloActual].enemigos[cont].nombreEnemigo != enemigo.name) cont += 1;

        nivel.pasillos[pasilloActual].enemigos[cont].vivo = false;
    }

    public void ModificarEnemigo(GameObject enemigo, float vida)
    {
        int cont = 0;
        int pasilloActual = int.Parse(nivel.scenes[nivel.sceneAfter.x, nivel.sceneAfter.y][2].ToString());

        while (nivel.pasillos[pasilloActual].enemigos[cont].nombreEnemigo != enemigo.name) cont += 1;

        nivel.pasillos[pasilloActual].enemigos[cont].ultimaPosicion = enemigo.transform.position;
        nivel.pasillos[pasilloActual].enemigos[cont].vida = vida;
        nivel.pasillos[pasilloActual].enemigos[cont].vivo = true;
    }


    public void AñadirEnemigoEnSala() { enemigosEnSala += 1; }
    public void QuitarEnemigoSala() { enemigosEnSala -= 1; Debug.Log("Enemigos en restantes: " + enemigosEnSala); }

    //Método público para cambiar de escena
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    //Método que pasa de nivel según si queda niveles existentes o no
    private void NextLevel()
    {

        //Si no queda
        if (scene + 1 == scenesInOrder.Length)
        {
            //Se cambia a la escena inicial
            ChangeScene(scenesInOrder[0]);
        }
        //Si queda
        else
        {
            //Se restablecen y se ajustan los valores necesarios y se pasa al proximo nivel
            ChangeScene(scenesInOrder[scene]);
        }
    }
}
