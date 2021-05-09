using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
    
    [SerializeField]
    GameObject dialogueBox;
    [SerializeField]
    TextMeshProUGUI dialogueText;
    [SerializeField]
    float textSpeed = 0.2f; //velocidad con la que se typean las letras

    [TextArea(3, 10)] //ampliamos la cantidad de líneas que pueden aparecer en el editor
    [SerializeField]


    string[] sentences = new string[5]; //array de frases de dialogo
    int numeroSentence = 0;

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
        }
        
    }
}
