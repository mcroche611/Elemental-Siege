﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    MonoBehaviour currentState = null;
    public float stateTime = 5f;

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
            //Debug.Log("Se ha producido una Reacción Elemental");
            CancelInvoke("StateTimeOut");
            currentState.enabled = false;
            currentState = null;
        }
              
    }

    private void StateTimeOut()
    {
        currentState.enabled = false;
        currentState = null;
    }
}
