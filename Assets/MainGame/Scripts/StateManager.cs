using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateManager : MonoBehaviour
{
    MonoBehaviour currentState = null;
    [SerializeField] float stateTime;
    
    public void NewElement(string elementalAtack)
    {
        MonoBehaviour element_state = GetComponent(elementalAtack.Split('_')[1]) as MonoBehaviour;

        if (currentState == null)
        {
            currentState = element_state;
            element_state.enabled = true;
            Invoke("StateTimeOut", stateTime);
        }
        else if (currentState == element_state)          
            Invoke("StateTimeOut", stateTime);     
        else if (currentState != element_state)
        {
            CancelInvoke("StateTimeOut");
            currentState.enabled = false;
            string element = elementalAtack.Split('_')[0];
            if (element == "Fuego")
            {
                if (currentState == GetComponent<Mojado>())
                {
                    GetComponentInChildren<Charco>().NoPuedeMojarse();
                    GetComponent<ElementalReactions>().VapolizadoDebil();
                }
                else
                {
                    GetComponent<ElementalReactions>().Sobrecargado();                   
                }
            }
            else if (element == "Agua")
            {
                if (currentState == GetComponent<Quemado>())
                {
                    GetComponent<ElementalReactions>().VapolizadoFuerte();
                }
                else
                {
                    GetComponent<Paralizar>().Paraliza();
                    GetComponent<ElementalReactions>().Electrocargado();
                }
            }
            else
            {
                GetComponent<Paralizar>().Paraliza();
                if (currentState == GetComponent<Electrocutado>())
                {
                    GetComponent<ElementalReactions>().Sobrecargado();
                }
                else
                {
                    GetComponentInChildren<Charco>().NoPuedeMojarse();
                    GetComponent<ElementalReactions>().Electrocargado();                   
                }
            }
            currentState = null;
        }           
    }

    public void StateTimeOut()
    {
        CancelInvoke("StateTimeOut");
        currentState.enabled = false;
        currentState = null;
    }

    public MonoBehaviour Estado()
    {
        return currentState;
    }
}
