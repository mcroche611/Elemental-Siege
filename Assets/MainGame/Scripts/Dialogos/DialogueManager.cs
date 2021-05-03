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

    string currentSentence;
    int numeroSentence = 0;
    int numeroLetra = 0;

    private void Awake()
    {
        instance = this;
    }
    public static DialogueManager GetInstance() //Para conseguir la referencia a dialogue manager haciendo gameManager.getInstance()
    {
        return instance;
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            
            if (dialogueText.text == sentences[numeroSentence])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = sentences[numeroSentence];
            }
            
        }
        
    }
   
    private void Start()
    {
        dialogueBox.SetActive(false);

        dialogueText.text = "";
        //StartDialogue2();

        //currentSentence = sentences[numeroSentence];
        //ActivarPanel();
        //ShowDialogueTyping();
        
    }
    

    public void StartDialogue() //va mal porque no aparece la box aunque esté activada
    {
        dialogueBox.SetActive(true);
        numeroLetra = 0;
        
            //Invoke("ShowDialogueTyping", 0.5f);
        InvokeRepeating("ShowDialogueTyping", 0f, 0.2f);
        
    }
    public void ActivarPanel()
    {
        dialogueBox.SetActive(true);
    }

    public void NextSentence() //para pasar de frase
    {
        if (numeroSentence < sentences.Length-1) //-1 quiza
        {
            numeroSentence++;
            Debug.Log(currentSentence);
            currentSentence = sentences[numeroSentence];
            
            Debug.Log("NUMEROSENTENCE " + numeroSentence + "S.LENGTH " + sentences.Length);
            Debug.Log(currentSentence);
        }
        else
        {
            //dialogueBox.SetActive(false);
        }
        
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
        {
            CancelInvoke();
            numeroLetra = 0;
            Debug.Log("NUMEROLETRA"+numeroLetra);
            NextSentence();
        }
        


        /*else
        {
            dialogueText.text = "";
            numeroLetra = 0;
            NextSentence();
        }
        */
    }




    //VERSIÓN 2 DEL SCRIPT DE DIÁLOGO, CON COROUTINES.
    //***********************************************
    public void StartDialogue2()
    {
        dialogueBox.SetActive(true);
        dialogueText.text = "";
        Time.timeScale = 0;

        numeroSentence = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        foreach (char c in sentences[numeroSentence])
        {
            dialogueText.text += c;
            yield return new WaitForSecondsRealtime(textSpeed);
        }
    }

    void NextLine()
    {
        if(numeroSentence < (sentences.Length-1))
        {
        numeroSentence++;
        dialogueText.text = "";
        StartCoroutine(TypeLine());
        }
        else
        {
            dialogueBox.SetActive(false);
            Time.timeScale = 1;
        }
        
    }
}
