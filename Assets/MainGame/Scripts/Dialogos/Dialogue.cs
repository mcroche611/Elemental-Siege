﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    [TextArea(3, 10)] //ampliamos la cantidad de líneas que pueden aparecer en el editor

    [SerializeField]
    string[] sentences = new string[1]; //array de frases de dialogo

    string currentSentence;
    int numeroSentence = 0;

    private void Start()
    {
        currentSentence = sentences[0];

    }

    void NextSentence()
    {
        numeroSentence++;
        currentSentence = sentences[numeroSentence];
        Debug.Log(currentSentence);
    }

}
