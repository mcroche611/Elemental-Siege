using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShield : MonoBehaviour
{
    [SerializeField]
    float tiempoCambio=10f; //Cada cuanto tiempo se cambia de un escudo a otro
    Escudo scriptEscudo;
    float contador;
    float fireHealth;
    float waterHealth;
    float electroHealth;
    void Start()
    {
        scriptEscudo = GetComponent<Escudo>(); //Empieza con el escudo predeterminado de fuego
        
    }
    private void Update()
    {
        contador += Time.deltaTime;
        if (contador>=tiempoCambio && scriptEscudo.ShieldHealth()>0)
        {
            contador = 0;
            scriptEscudo.enabled = false;
            //GuardaEscudo();
            EscudoAleatorio();
            scriptEscudo.enabled = true;
        }
    }
    void CambiaFuego()
    {
        Debug.Log("Escudo de fuego activado");
        
        scriptEscudo.CambioEscudo("Fuego");
        
        
        
    }
   void CambiaAgua()
   {
       Debug.Log("Escudo de agua activado");
       
       scriptEscudo.CambioEscudo("Agua");
        
       

   }
    void CambiaElectro()
    {
        Debug.Log("Escudo de electro activado");
       
        scriptEscudo.CambioEscudo("Electrico");
        
        

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
     /*
    void GuardaEscudo()
     {
        float shieldLeft = scriptEscudo.ShieldHealth();
        string tipoEscudo = scriptEscudo.TipoEscudo();

        switch (tipoEscudo)
        {
            case "Fuego":
                fireHealth = shieldLeft;
                Debug.Log("fireHealth: " + fireHealth);
                break;

            case "Agua":
                waterHealth = shieldLeft;
                Debug.Log("waterHealth: " + fireHealth);
                break;

            case "Electrico":
                electroHealth = shieldLeft;
                Debug.Log("electroHealth: " + fireHealth);
                break;
        }


     }*/
}
