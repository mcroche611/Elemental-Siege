using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*Para hablar con el GameManager basta referenciarlo en alguno de nuestros scripts de esta forma
     GameManager.GetInstance ().NombreMétodoPúblico ();*/


    private static GameManager instance;

    [SerializeField] float ataque, bonoAgua, bonoFuego, bonoElectricidad;

    //int hpPlayer;

    Transform playerTf;
    GameObject player;

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

    //public void SetPlayerTransform(Transform tf)
    //{
    //    playerTf = tf;
    //}

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



    //public void SetHpPlayer(int vidaPlayer)
    //{
    //    hpPlayer = vidaPlayer;
    //}

    //public int GetVidaPlayer()
    //{
    //    return hpPlayer;
    //}
}
