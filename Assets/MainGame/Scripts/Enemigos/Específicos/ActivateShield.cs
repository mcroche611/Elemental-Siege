﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShield : MonoBehaviour
{
    [SerializeField]
    float tiempoCambio=10f; //Cada cuanto tiempo se cambia de un escudo a otro
    Escudo scriptEscudo;
    float contador;
    [SerializeField]
    GameObject escudoFisicoAgua;
    [SerializeField]
    GameObject escudoFisicoFuego;
    [SerializeField]
    GameObject escudoFisicoElectro;
    void Start()
    {
        //Empieza con el escudo predeterminado de fuego
        scriptEscudo = GetComponent<Escudo>();
        escudoFisicoFuego.SetActive(true);
    }
    private void Update()
    {
        contador += Time.deltaTime;
        if (contador>=tiempoCambio && scriptEscudo.ShieldHealth()>0)
        {
            contador = 0;
            scriptEscudo.enabled = false;
            EscudoAleatorio();
            scriptEscudo.enabled = true;
        }
    }
    void CambiaFuego()
    {
        
        
        scriptEscudo.CambioEscudo("Fuego");
        escudoFisicoFuego.SetActive(true);
        escudoFisicoAgua.SetActive(false);
        escudoFisicoElectro.SetActive(false);
        
        
    }
   void CambiaAgua()
   {
       
       
       scriptEscudo.CambioEscudo("Agua");
       
        escudoFisicoAgua.SetActive(true);
        escudoFisicoElectro.SetActive(false);
        escudoFisicoFuego.SetActive(false);

    }
    void CambiaElectro()
    {
        
       
        scriptEscudo.CambioEscudo("Electrico");
        escudoFisicoElectro.SetActive(true);
        escudoFisicoFuego.SetActive(false);
        escudoFisicoAgua.SetActive(false);
        


    }
    void EscudoAleatorio()
    {
        int rnd = Random.Range(0, 3);
       
        switch (rnd)
        {
            //SI SALE UN 0 CAMBIA A FUEGO, SI SALE UN 1 A AGUA Y SI SALE UN 2 A ELECTRO
            case 0:

                
                    CambiaFuego();
                
                break;

            case 1:
                
                    CambiaAgua();
                
                break;

            case 2:

                CambiaElectro();

                break;

        }
        Debug.Log("Cambio a escudo: " + rnd);
    }
     
}
