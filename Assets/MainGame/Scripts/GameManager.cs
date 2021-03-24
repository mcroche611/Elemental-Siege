using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*Para hablar con el GameManager basta referenciarlo en alguno de nuestros scripts de esta forma
     GameManager.GetInstance ().NombreMétodoPúblico ();*/


    private static GameManager instance;
    [SerializeField]
    private int health;

    [SerializeField]
    private int maxMana;
    private float mana;

    [SerializeField]
    private float manaRegSpeed;

    public float playerSpeed; //PREGUNTAR A GUILLERMO VARIABLE PUBLICA?
    //velocity = GameManager.GetInstance().playerSpeed; añadir a script de movimiento Consoller

    [SerializeField]
    private int damageBonus;

    [SerializeField]
    private float attack;


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
        mana = maxMana;  
            
    }
    public static GameManager GetInstance() //Para conseguir la referencia a game maager haciendo gameManager.getInstance()
    {
        return instance;
    }


    void Update()
    {
        if (mana < maxMana)
        {
            mana += manaRegSpeed * Time.deltaTime;
        }
        else mana = maxMana;
        /*if (Input.GetKeyDown("space"))
        {
            RestaMana(30);
        }
        Debug.Log(mana);*/
    }
    
    public void RestaMana(int cantidad) //Se invoca al realizar una habilidad elemental
    {
        if (mana>=cantidad)
        {
            mana -= cantidad;
        }
        
    }
}
