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
    ActivateButton button;

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
        //dialogueBox.SetActive(false);

        button = GetComponent<ActivateButton>();

        dialogueText.text = "";

        SetDialogue();

        if (numDialogue == 0)
        {
            StartDialogue();
        }
    }

    private void SetDialogue()
    {
        string num = "Scene" + numDialogue.ToString();
        bool inDialogue = false;
        int i = 0;

        if (File.Exists(filePath))
        {
            StreamReader dialogue = new StreamReader(filePath);
            while (!dialogue.EndOfStream)
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
        else
            throw new Exception("Archivo de diálogo no encontrado");
    }

    private void Update()
    {
        if (Input.GetKeyDown("space")) //si el jugador pulsa espacio
        {
            
            if (dialogueText.text == sentences[numeroSentence]) //y el texto ya se ha terminado de poner
            {
                NextSentence(); //pasa a la siguiente
            }
            else //si no ha terminado la línea de diálogo
            {
                StopAllCoroutines(); //para de escribir letra a letra
                dialogueText.text = sentences[numeroSentence]; //completa el texto
            }
            
        }
        
    }
   
    
    public void StartDialogue()
    {
        if (sentences != null)
        {
            dialogueGoingOn = true;
            dialogueBox.SetActive(true);
            dialogueText.text = "";
            Time.timeScale = 0;
            numeroSentence = 0;
            StartCoroutine(TypeSentence());
        }
        else
        {
            Debug.LogWarningFormat("Diálogo de la escena {0} no encontrado.", numDialogue);
        }
    }
    IEnumerator TypeSentence()
    {
        foreach (char c in sentences[numeroSentence])
        {
            dialogueText.text += c;
            if (numDialogue == 0 && (numeroSentence == 0 || numeroSentence == 1))
                dialogueText.color = Color.blue;
            else
                dialogueText.color = Color.black;
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
            dialogueGoingOn = false;
            dialogueBox.SetActive(false);
            Time.timeScale = 1;

            if (button != null)
            {
                button.SetActiveButton();
            }
        }
        
    }

    public bool DialogueGoing()
    {
        return dialogueGoingOn;
    }
}
