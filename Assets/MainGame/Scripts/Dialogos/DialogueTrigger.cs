using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    private void Start()
    {

    }
    void StartDialogue()
    {
        DialogueManager.GetInstance().ActivarPanel();
        
        DialogueManager.GetInstance().ShowDialogueTyping();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartDialogue();
        
    }
}
