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

    private void Update()
    {
        if (numeroSentence >= currentSentence.Length)
        {
            CancelInvoke();
        }
    }

    private void Start()
    {
        currentSentence = sentences[numeroSentence];
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
        
            //Invoke("ShowDialogueTyping", 0.5f);
        InvokeRepeating("ShowDialogueTyping", 0f, 0.2f);
        
    }
    public void ActivarPanel()
    {
        dialogueBox.SetActive(true);
    }

    public void NextSentence() //para pasar de frase
    {
        if (numeroSentence < sentences.Length)
        {
            numeroSentence++;
            Debug.Log(currentSentence);
            currentSentence = sentences[numeroSentence];
            
            Debug.Log("NUMEROSENTENCE " + numeroSentence + "S.LENGTH " + sentences.Length);
            Debug.Log(currentSentence);
        }
        
    }

    public void ShowDialogue()
    {
        ActivarPanel();
        dialogueText.text = currentSentence;
    }
    public void ShowDialogueTyping() //para que vaya mostrando el dialogo poco a poco. ponerlo con invoke
    {
        

        /*if (currentSentence != null && numeroLetra < currentSentence.Length)
        {
            dialogueText.text += currentSentence[numeroLetra];
            numeroLetra++;

        }
        else
        {
            //CancelInvoke();
            numeroLetra = 0;
            Debug.Log("NUMEROLETRA"+numeroLetra);
            NextSentence();
        }
        */


        /*else
        {
            dialogueText.text = "";
            numeroLetra = 0;
            NextSentence();
        }
        */
    }

    IEnumerator TypeLine()
    {
        foreach (char c in currentSentence)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
