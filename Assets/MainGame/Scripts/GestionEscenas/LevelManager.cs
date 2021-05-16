using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelManager : MonoBehaviour
{
    const string filePath = "Assets/MainGame/Resources/";

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
        public Coor sceneNow;
        public Coor sceneAfter;
        public Coor sceneIni;
    }

    private string[,] CargarNivel(string levelName, out int xPos, out int yPos)
    {
        string fileName = filePath + levelName + ".txt";
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
        int xPos, yPos;

        Escena s;

        s.scenes = CargarNivel(nivel, out xPos, out yPos);

        s.habitacionDescubierta = new bool[s.scenes.GetLength(0), s.scenes.GetLength(1)];
        int pasillos = 0;

        for (int i = 0; i < s.scenes.GetLength(0); i++)
        {
            for (int j = 0; j < s.scenes.GetLength(1); j++)
            {
                s.habitacionDescubierta[i, j] = false;
                char c = s.scenes[i, j][1];
                if (c == 'P')
                    pasillos += 1;
            }
        }

        s.pasillos = new Pasillo[pasillos];

        for (int i = 0; i < s.pasillos.Length; i++)
        {
            s.pasillos[i].enemigos = new Enemigo[50];
            s.pasillos[i].pc = 0;
        }

        s.sceneNow.x = xPos;
        s.sceneNow.y = yPos;
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

    public void AñadirEnemigoEnSala()
    {
        enemigosEnSala += 1;
    }

    public void QuitarEnemigoSala()
    {
        enemigosEnSala -= 1;
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
}
