using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalAttack : MonoBehaviour
{
    //Variables accesibles desde el editor
    public GameObject fuego, agua, electricidad;


    [SerializeField] int manaAgua, manaFuego, manaElectro;
    [SerializeField] float coolDown;
    
    float cont = 0;
    Mana quitaMana;

    private void Start()
    {
        quitaMana = GetComponent<Mana>();
    }

    private void Update()
    {
        if (cont <= 0 && Input.GetMouseButtonDown(1))
        {
            string elementoActual = GetComponent<ElementChanger>().ElementoActual();
            Rotation();
            if (elementoActual == "Fuego" && quitaMana.RestaMana(manaFuego))
            {
                SoundManager.GetInstance().fireBallSound();
                Instantiate<GameObject>(fuego, transform.position, Rotation());
            }
            else 
            {
                if (elementoActual == "Electricidad" && quitaMana.RestaMana(manaElectro))
                {
                    SoundManager.GetInstance().electricBallSound();
                    Instantiate<GameObject>(electricidad, transform.position, Rotation());
                }
                else
                {
                    if (quitaMana.RestaMana(manaAgua))
                    {
                        SoundManager.GetInstance().waterBallSound();
                        Instantiate<GameObject>(agua, transform.position, Rotation());
                    }
                }
            }
            cont = coolDown;
        }       
        cont -= Time.deltaTime;
    }

    private Quaternion Rotation()
    {
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 vector = new Vector2(mouseWorldPosition.x - transform.position.x, mouseWorldPosition.y - transform.position.y);       
        float angulo = Mathf.Atan2(vector.y, vector.x) * 180 / Mathf.PI;
        return Quaternion.Euler(new Vector3(0f, 0f, angulo));
    }
}
