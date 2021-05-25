using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelManager : MonoBehaviour
{
    const string filePath = "/Resources/";

    private static LevelManager instance;

    public static LevelManager GetInstance()
    {    
        return instance;
    }

    void Awake()
    {
        //Si no hay ninguna instancia creada almacenamos aqui la instancia actual
        if (instance == null)
        {            
            instance = this;
            //Nos aseguramos de que el objeto al que esta asociado este script no se destruira al cambiar de escena
            DontDestroyOnLoad(this.gameObject);
            nivel = InicializaNivel("nivel" + numNivel);

            ////// Comentado para generalizar en un solo método la carga del nivel
            //if (numNivel == 1)
            //    nivel = Nivel1();
            //else if (numNivel == 2)
            //    nivel = Nivel2();
            //else
            //    nivel = Nivel3();
        }
        else
        {
            //Si ya existe un gameobject con un componente instancia de esta clase (es decir ya hay un GM) no necesitamos uno nuevo
            Destroy(this.gameObject);
        }
    }

    public int numNivel;

    public GameObject nasnas;
    GameObject player;

    public Transform escaleras;
    Vector2 posEscaleras;

    bool iniPlayer = true;
    bool haMuerto = false;

    private void Start()
    {   
        posEscaleras = escaleras.position;
        player = (GameObject) Instantiate(nasnas, posEscaleras, nasnas.transform.rotation);
        RoomManager.GetInstance().SetUpCamera(player.transform);
        iniPlayer = false;
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level != 1)
        {
            if (!iniPlayer)
            {
                if (!haMuerto)
                {
                    RoomManager.GetInstance().SetUpCamera(player.transform);
                    RoomManager.GetInstance().SetUpPlayer(orientacionUltimaPuerta, player.transform);
                    nivel.sceneAfter.x = nivel.sceneNow.x;
                    nivel.sceneAfter.y = nivel.sceneNow.y;
                    enemigosEnSala = 0;
                }
                else
                {
                    for (int i = 0; i < nivel.scenes.GetLength(0); i++)
                    {
                        for (int j = 0; j < nivel.scenes.GetLength(1); j++)
                        {
                            char c = nivel.scenes[i, j][1];
                            if (c == 'P' || c == 'S')
                                nivel.habitacionDescubierta[i, j] = false;
                        }
                    }
                    for (int i = 0; i < nivel.pasillos.Length; i++)
                    {
                        nivel.pasillos[i].enemigos = new Enemigo[50];
                        nivel.pasillos[i].pc = 0;
                    }
                    for (int i = 0; i < nivel.jarronesEnHabitaciones.Length; i++)
                    {
                        nivel.jarronesEnHabitaciones[i].jarrones = new Jarron[50];
                        nivel.jarronesEnHabitaciones[i].pc = 0;
                    }
                    nivel.sceneNow.x = nivel.sceneIni.x;
                    nivel.sceneNow.y = nivel.sceneIni.y;
                    nivel.sceneAfter.x = nivel.sceneNow.x;
                    nivel.sceneAfter.y = nivel.sceneNow.y;
                    enemigosEnSala = 0;
                    player = (GameObject)Instantiate(nasnas, posEscaleras, nasnas.transform.rotation);
                    RoomManager.GetInstance().SetUpCamera(player.transform);
                    haMuerto = false;
                }
            }
        }
    }

    string orientacionUltimaPuerta;
    int enemigosEnSala = 0;
    
    Escena nivel;

    struct Coor
    {
        public int x, y;
    }

    struct Enemigo
    {
        public string nombreEnemigo;
        public Vector2 ultimaPosicion;
        public float vida;
        public bool vivo;    
    }

    struct Jarron
    {
        public string nombre;
        public bool destruido;
    }

    struct Jarrones
    {
        public Jarron[] jarrones;
        public int pc;
    }

    struct Pasillo
    {
        public Enemigo[] enemigos;
        public int pc;
    }

    struct Escena
    {
        public string[,] scenes;
        public bool[,] habitacionDescubierta;
        public Pasillo[] pasillos;
        public Jarrones[] jarronesEnHabitaciones; 
        public Coor sceneNow;
        public Coor sceneAfter;
        public Coor sceneIni;
    }

    private string[,] CargarNivel(string levelName, out int xPos, out int yPos)
    {
        
        
        string fileName = Application.dataPath + filePath + levelName + ".txt";
        Debug.Log("Level file path: " + fileName);

        int maxFil = 0, maxCol = 0;
        xPos = -1; 
        yPos = -1;

        if (File.Exists(fileName))
        {
            StreamReader dialogue = new StreamReader(fileName);
            while (!dialogue.EndOfStream)
            {
                string s = dialogue.ReadLine();
                if (s != null)
                {
                    maxFil++;
                    string[] rooms = s.Split(',');
                    if (rooms.Length > maxCol)
                    {
                        maxCol = rooms.Length;
                    }
                }
            }
            dialogue.Close();

            string[,] nivel = new string[maxFil, maxCol];

            int fil = 0;

            dialogue = new StreamReader(fileName);
            while (!dialogue.EndOfStream)
            {
                string s = dialogue.ReadLine();
                if (s != null)
                {
                    string[] rooms = s.Split(',');
                    for (int col = 0; col < rooms.Length; col++)
                    {
                        if (rooms[col][0] == '*')
                        {
                            xPos = fil;
                            yPos = col;

                            nivel[fil, col] = rooms[col].Substring(1);
                        }
                        else
                        {
                            nivel[fil, col] = rooms[col];
                        }
                    }
                    fil++;
                }
            }
            dialogue.Close();

            if (xPos < 0 || yPos < 0)
                throw new System.Exception("Habitación inicial no encontrada");

            return nivel;
        }
        else
            throw new System.Exception(fileName + " no encontrado");        
    }

    //////// Comentados por la generalización con el InicializaNivel()
    //private Escena Nivel1()
    //{
    //    return InicializaNivel("nivel1");
    //}

    //private Escena Nivel2()
    //{
    //    return InicializaNivel("nivel2");
    //}

    //private Escena Nivel3()
    //{
    //    return InicializaNivel("nivel3");
    //}

    private Escena InicializaNivel(string nivel)
    {
        int iniX, iniY;

        Escena s;

        s.scenes = CargarNivel(nivel, out iniX, out iniY);

        s.habitacionDescubierta = new bool[s.scenes.GetLength(0), s.scenes.GetLength(1)];
        int pasillos = 0;
        int numHabitaciones = 0;

        for (int i = 0; i < s.scenes.GetLength(0); i++)
        {
            for (int j = 0; j < s.scenes.GetLength(1); j++)
            {           
                s.habitacionDescubierta[i, j] = false;
                char c = s.scenes[i, j][1];
                if (c != '-')
                {
                    numHabitaciones += 1;
                    if (c == 'P')
                        pasillos += 1;
                }          
            }
        }

        s.pasillos = new Pasillo[pasillos];

        for (int i = 0; i < s.pasillos.Length; i++)
        {
            s.pasillos[i].enemigos = new Enemigo[50];
            s.pasillos[i].pc = 0;
        }

        s.jarronesEnHabitaciones = new Jarrones[numHabitaciones];

        for (int i = 0; i < s.jarronesEnHabitaciones.Length; i++)
        {
            s.jarronesEnHabitaciones[i].jarrones = new Jarron[50];
            s.jarronesEnHabitaciones[i].pc = 0;
        }

        s.sceneNow.x = iniX;
        s.sceneNow.y = iniY;
        s.sceneAfter.x = s.sceneNow.x;
        s.sceneAfter.y = s.sceneNow.y;
        s.sceneIni.x = s.sceneNow.x;
        s.sceneIni.y = s.sceneNow.y;

        return s;
    }

    // No hace falta porque es mejor leer los niveles desde los archivos
    private string[,] EscenasNivel(int n)
    {
        string[,] escenas;

        if (n == 1)
        {
            escenas = new string[5, 9]  {{ "---","---", "1ME", "1S5", "1P7", "1S6", "1P8", "1S7", "1P9"},
                                         {"---", "---", "---", "1P5", "---", "1P6", "---", "---", "---"},
                                         {"---", "---", "---", "1S3", "1P4", "1S4", "---", "---", "---"},
                                         {"---", "---", "---", "1P3", "---", "1MF", "---", "---", "---"},
                                         {"1P0", "1S0", "1P1", "1S1", "1P2", "1S2", "1MA", "---", "---"}};
        }
        else if (n == 2)
        {
            escenas = new string[8, 7]  {{ "---","2S5", "2P6", "2S6", "2P7", "2S7", "2P8"},
                                         {"---", "---", "---", "2P5", "---", "---", "---"},
                                         {"---", "---", "---", "2S4", "---", "---", "---"},
                                         {"---", "---", "---", "SP4", "---", "---", "---"},
                                         {"---", "2S1", "2P2", "2S2", "2P3", "2S3", "2MA"},
                                         {"---", "2P1", "---", "2ME", "---", "---", "---"},
                                         {"2P0", "2S0", "---", "---", "---", "---", "---"},
                                         {"---", "2MF", "---", "---", "---", "---", "---"}};
        }
        else escenas = new string[1, 2] { { "3P0", "Iblis" } };

        return escenas;
    }

    // No hace falta pq InicializaNivel y CargaNivel ya lo hacen y desde el archivo, que es mejor
    private Escena Nivel(string[,] escenas, int iniX, int iniY)
    {
        Escena s;

        s.scenes = new string[escenas.GetLength(0), escenas.GetLength(1)];

        for (int i = 0; i < s.scenes.GetLength(0); i++)
        {
            for (int j = 0; j < s.scenes.GetLength(1); j++)
            {
                s.scenes[i, j] = escenas[i, j];
            }
        }

        s.habitacionDescubierta = new bool[s.scenes.GetLength(0), s.scenes.GetLength(1)];

        int pasillos = 0;
        int numHabitaciones = 0;

        for (int i = 0; i < s.scenes.GetLength(0); i++)
        {
            for (int j = 0; j < s.scenes.GetLength(1); j++)
            {
                s.habitacionDescubierta[i, j] = false;
                char c = s.scenes[i, j][1];
                if (c != '-')
                {
                    numHabitaciones += 1;
                    if (c == 'P')
                        pasillos += 1;
                }
            }
        }

        s.pasillos = new Pasillo[pasillos];

        for (int i = 0; i < s.pasillos.Length; i++)
        {
            s.pasillos[i].enemigos = new Enemigo[50];
            s.pasillos[i].pc = 0;
        }

        s.jarronesEnHabitaciones = new Jarrones[numHabitaciones];

        for (int i = 0; i < s.jarronesEnHabitaciones.Length; i++)
        {
            s.jarronesEnHabitaciones[i].jarrones = new Jarron[50];
            s.jarronesEnHabitaciones[i].pc = 0;
        }

        s.sceneNow.x = iniX;
        s.sceneNow.y = iniY;
        s.sceneAfter.x = s.sceneNow.x;
        s.sceneAfter.y = s.sceneNow.y;
        s.sceneIni.x = s.sceneNow.x;
        s.sceneIni.y = s.sceneNow.y;

        return s;
    }

    public void CompletarHabitacion()
    {
        nivel.habitacionDescubierta[nivel.sceneNow.x, nivel.sceneNow.y] = true;
    }

    public bool HabiaEntradoAntes()
    {
        return nivel.habitacionDescubierta[nivel.sceneNow.x, nivel.sceneNow.y];
    }

    public char TipoHabitacion()
    {
        return nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y][1];
    }

    public string GetHabitación()
    {
        return nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y];
    }

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

    public void NuevoEnemigo(string enemigo)
    {
        int pasilloActual = int.Parse(nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y][2].ToString());

        nivel.pasillos[pasilloActual].enemigos[nivel.pasillos[pasilloActual].pc].nombreEnemigo = enemigo;
        nivel.pasillos[pasilloActual].enemigos[nivel.pasillos[pasilloActual].pc].vivo = true;
        nivel.pasillos[pasilloActual].pc += 1;
    }

    public void NuevoJarron(string jarron)
    {
        int habitacionActual = int.Parse(nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y][2].ToString()); ;
        if (TipoHabitacion() == 'S')
            habitacionActual += nivel.pasillos.Length;
           
        nivel.jarronesEnHabitaciones[habitacionActual].jarrones[nivel.jarronesEnHabitaciones[habitacionActual].pc].nombre = jarron;
        nivel.jarronesEnHabitaciones[habitacionActual].jarrones[nivel.jarronesEnHabitaciones[habitacionActual].pc].destruido = false;
        nivel.jarronesEnHabitaciones[habitacionActual].pc += 1;
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

    public void IniJarron(GameObject jarron)
    {
        int habitacionActual = int.Parse(nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y][2].ToString()); ;
        if (TipoHabitacion() == 'S')
            habitacionActual += nivel.pasillos.Length;
        int cont = 0;

        while (nivel.jarronesEnHabitaciones[habitacionActual].jarrones[cont].nombre != jarron.name) cont += 1;

        if (nivel.jarronesEnHabitaciones[habitacionActual].jarrones[cont].destruido)
        {
            Destroy(jarron);
        }
    }

    public void MatarEnemigo(GameObject enemigo)
    {
        int pasilloActual = int.Parse(nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y][2].ToString());
        int cont = 0;

        while (nivel.pasillos[pasilloActual].enemigos[cont].nombreEnemigo != enemigo.name) cont += 1;

        nivel.pasillos[pasilloActual].enemigos[cont].vivo = false;
    }

    public void DestruirJarron(GameObject jarron)
    {
        int habitacionActual = int.Parse(nivel.scenes[nivel.sceneNow.x, nivel.sceneNow.y][2].ToString()); ;
        if (TipoHabitacion() == 'S')
            habitacionActual += nivel.pasillos.Length;
        int cont = 0;

        while (nivel.jarronesEnHabitaciones[habitacionActual].jarrones[cont].nombre != jarron.name) cont += 1;

        nivel.jarronesEnHabitaciones[habitacionActual].jarrones[cont].destruido = true;
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

    public void AñadirEnemigoEnSala()
    {
        enemigosEnSala += 1;
    }

    public void QuitarEnemigoSala()
    {
        enemigosEnSala -= 1;

        if (SalaCompletada())
        {
            RoomManager.GetInstance().AbrirPuertas();

            if (GetHabitación() == "Iblis")
            {
                GameManager.GetInstance().GMOcultarMostrarCanvas(false);
                DialogueManager.GetInstance().StartDialogue();
            }
        }    
    }

    public bool SalaCompletada()
    {
        return enemigosEnSala == 0;
    }

    public string GetOrientacion()
    {
        return orientacionUltimaPuerta;
    }
    
    public void PrimeraHabitacion()
    {
        haMuerto = true;
        SceneManager.LoadScene(nivel.scenes[nivel.sceneIni.x, nivel.sceneIni.y]);      
    }

    public void FinNivel()
    {
        Destroy(this.gameObject);
        Destroy(player);
    }

    public void EscenaDeMuerte()
    {
        SceneManager.LoadScene("EscenaMuerte");
    }
}
