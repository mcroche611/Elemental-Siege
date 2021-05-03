using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    /*
    [TextArea(3, 10)] //ampliamos la cantidad de líneas que pueden aparecer en el editor

    [SerializeField]
    string[] sentences = new string[1]; //array de frases de dialogo

    string currentSentence;
    int numeroSentence = 0;
    */
    private void Start()
    {
        gameObject.SetActive(true);
    }
    /*void StartDialogue()
    {
        DialogueManager.GetInstance().ActivarPanel();
        
        DialogueManager.GetInstance().ShowDialogueTyping();
        
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogueManager.GetInstance().StartDialogue();
        Debug.Log("ENTRADO AL TRIGGER");
    }
}
