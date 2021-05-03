﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    [SerializeField]
    string[] dialogueSentences;


    [SerializeField]
    GameObject dialogueBox;
    [SerializeField]
    TextMeshProUGUI dialogueText;
    [SerializeField]
    float lettersPerSecond; //velocidad con la que se typean las letras


    [TextArea(3, 10)] //ampliamos la cantidad de líneas que pueden aparecer en el editor
    [SerializeField]
    string[] sentences = new string[1]; //array de frases de dialogo

    string currentSentence;
    int numeroSentence = 0;
    int numeroLetra = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentSentence = sentences[0];
        StartDialogue();
        //dialogueText = "";
        //ActivarPanel();
        //ShowDialogueTyping();
        
    }
    public static DialogueManager GetInstance() //Para conseguir la referencia a dialogue manager haciendo gameManager.getInstance()
    {
        return instance;
    }

    public void StartDialogue()
    {
        numeroLetra = 0;
        
            ShowDialogueTyping();
        
    }
    public void ActivarPanel()
    {
        dialogueBox.SetActive(true);
    }

    public void NextSentence() //para pasar de frase
    {
        numeroSentence++;
        currentSentence = sentences[numeroSentence];
        Debug.Log(currentSentence);
    }

    public void ShowDialogue()
    {
        ActivarPanel();
        dialogueText.text = currentSentence;
    }
    public void ShowDialogueTyping() //para que vaya mostrando el dialogo poco a poco. ponerlo con invoke
    {
        if (currentSentence != null && numeroLetra < currentSentence.Length)
        {
            dialogueText.text += currentSentence[numeroLetra];
            numeroLetra++;
        }
        else
            numeroLetra = 0;
        
    }

}
