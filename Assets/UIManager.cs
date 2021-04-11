using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite fuego, agua, electricidad;
    Image _elementoActual, _elemento1, _elemento2;
    public GameObject barraDeVida, barraDeMana, elementoActual, elemento1, elemento2;
    Vector2 maxBarraDeVida, maxBarraDeMana;
    GridLayoutGroup _barraDeVida, _barraDeMana;

    void Start()
    {
        GameManager.GetInstance().SetUIManager(this);
        
        _barraDeVida = barraDeVida.GetComponent<GridLayoutGroup>();
        maxBarraDeVida = _barraDeVida.cellSize;
        _barraDeMana = barraDeMana.GetComponent<GridLayoutGroup>();
        maxBarraDeMana = _barraDeMana.cellSize;
        _elementoActual = elementoActual.GetComponent<Image>();
        _elemento1 = elemento1.GetComponent<Image>();
        _elemento2 = elemento2.GetComponent<Image>();
        
    }

    public void ActualizarVida(float porcentajeVida)
    {
        _barraDeVida.cellSize = new Vector2(porcentajeVida * maxBarraDeVida.x, maxBarraDeVida.y);     
    }

    
    public void ActualizarMana(float porcentajeMana)
    {
        _barraDeMana.cellSize = new Vector2(porcentajeMana * maxBarraDeMana.x, maxBarraDeVida.y);      
    }
    
    public void ActualizarElementos(string elementoEquipado)
    {

        if (elementoEquipado == "Fuego")
        {
            _elementoActual.sprite = fuego;
            _elemento1.sprite = agua;
            _elemento2.sprite = electricidad;
        }
        else if (elementoEquipado == "Agua")
        {
            _elementoActual.sprite = agua;
            _elemento1.sprite = electricidad;
            _elemento2.sprite = fuego;
        }
        else
        {
            _elementoActual.sprite = electricidad;
            _elemento1.sprite = fuego;
            _elemento2.sprite = agua;
        }
        
    }
}
