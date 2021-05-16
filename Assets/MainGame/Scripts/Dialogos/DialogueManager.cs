using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    
    [SerializeField]
    GameObject dialogueBox;
    [SerializeField]
    TextMeshProUGUI dialogueText;
    [SerializeField]
    float textSpeed = 0.2f; //velocidad con la que se typean las letras
    [SerializeField] int numDialogue; //número del diálogo a leer

    const string filePath = "Assets/MainGame/Resources/dialogue.txt";

    [TextArea(3, 10)] //ampliamos la cantidad de líneas que pueden aparecer en el editor

    //[SerializeField]
    string[] sentences; //array de frases de dialogo
    int numeroSentence = 0;

    static bool dialogueGoingOn; //bool con el propósito de que no se pueda pasar el juego si hay un diálogo


    private void Awake()
    {
        instance = this;
    }
    public static DialogueManager GetInstance() //Para conseguir la referencia a dialogue manager haciendo gameManager.getInstance()
    {
        return instance;
    }
    
    private void Start()
    {
        dialogueBox.SetActive(false);

        dialogueText.text = "";

        SetDialogue();
    }

    private void SetDialogue()
    {
        string num = "Scene" + numDialogue.ToString();
        bool inDialogue = false;
        int i = 0;

        StreamReader dialogue = new StreamReader(filePath);
        while(!dialogue.EndOfStream)
        {
            string s = dialogue.ReadLine();
            if (s == num)
            {
                int numSentences = int.Parse(dialogue.ReadLine());
                sentences = new string[numSentences];
                inDialogue = true;
            }
            else if (inDialogue && s != "")
            {
                sentences[i] = s;
                i++;
            }
            else
            {
                inDialogue = false;
            }
        }
        dialogue.Close();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            
            if (dialogueText.text == sentences[numeroSentence])
            {
                NextSentence();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = sentences[numeroSentence];
            }
            
        }
        
    }
   
    


    //VERSIÓN 2 DEL SCRIPT DE DIÁLOGO, CON COROUTINES.
    //***********************************************
    public void StartDialogue2()
    {
        dialogueGoingOn = true;
        dialogueBox.SetActive(true);
        dialogueText.text = "";
        Time.timeScale = 0;
        numeroSentence = 0;
        StartCoroutine(TypeSentence());
    }
    IEnumerator TypeSentence()
    {
        foreach (char c in sentences[numeroSentence])
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }

    void NextSentence()
    {
        if(numeroSentence < (sentences.Length-1))
        {
        numeroSentence++;
        dialogueText.text = "";
        StartCoroutine(TypeSentence());
        }
        else
        {
            dialogueBox.SetActive(false);
            Time.timeScale = 1;
            dialogueGoingOn = false;
        }
        
    }

    public bool DialogueGoing()
    {
        return dialogueGoingOn;
    }
}
