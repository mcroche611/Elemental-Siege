﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite fuego, agua, electricidad;
    public Image elementoActual, elemento1, elemento2;
    Vector2 maxBarraDeVida, maxBarraDeMana;
    public GridLayoutGroup barraDeVida, barraDeMana;

    void Start()
    {
        GameManager.GetInstance().SetUIManager(this);
        
        maxBarraDeVida = barraDeVida.cellSize;
        maxBarraDeMana = barraDeMana.cellSize;    
    }

    public void ActualizarVida(float porcentajeVida)
    {
        barraDeVida.cellSize = new Vector2(porcentajeVida * maxBarraDeVida.x, maxBarraDeVida.y);     
    }

    
    public void ActualizarMana(float porcentajeMana)
    {
        barraDeMana.cellSize = new Vector2(porcentajeMana * maxBarraDeMana.x, maxBarraDeVida.y);      
    }
    
    public void ActualizarElementos(string elementoEquipado)
    {

        if (elementoEquipado == "Fuego")
        {
            elementoActual.sprite = fuego;
            elemento1.sprite = electricidad;
            elemento2.sprite = agua;
        }
        else if (elementoEquipado == "Agua")
        {
            elementoActual.sprite = agua;
            elemento1.sprite = fuego;
            elemento2.sprite = electricidad;
        }
        else
        {
            elementoActual.sprite = electricidad;
            elemento1.sprite = agua;
            elemento2.sprite = fuego;
        }
        
    }
}
