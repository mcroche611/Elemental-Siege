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
        {
            CancelInvoke("StateTimeOut");
            Invoke("StateTimeOut", stateTime);
        }
        else if (currentState != element_state)
        {
            CancelInvoke("StateTimeOut");
            currentState.enabled = false;
            string element = elementalAtack.Split('_')[0];
            if (element == "Fuego")
            {
                if (currentState == GetComponent<Mojado>())
                {
                    GetComponent<Vapolizado>().Vapolizado_Debil();
                    Debug.Log("Se ha producido la RE vaporizado (débil)");
                }
                else
                {
                    Debug.Log("Se ha producido la RE Sobrecaragado");
                    
                }
            }
            else if (element == "Agua")
            {
                if (currentState == GetComponent<Quemado>())
                {
                    GetComponent<Vapolizado>().Vapolizado_Fuerte();
                    Debug.Log("Se ha producido la RE vaporizado (fuerte)");
                }
                else
                {
                    Debug.Log("Se ha producido la RE Electrocargado");
                    GetComponent<Electrocargado>().Electrocargado_();
                }
            }
            else
            {
                GetComponent<Paralizar>().Paraliza();
                if (currentState == GetComponent<Quemado>())
                {
                    Debug.Log("Se ha producido RE Sobrecargado");
                }
                else
                {
                    Debug.Log("Se ha producido la RE Ectrocargado");
                    GetComponent<Electrocargado>().Electrocargado_();
                }
            }
            currentState = null;
        }
              
    }

    private void StateTimeOut()
    {
        currentState.enabled = false;
        currentState = null;
    }
}
