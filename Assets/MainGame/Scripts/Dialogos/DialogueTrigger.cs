using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DialogueManager.GetInstance().StartDialogue2();
        Debug.Log("ENTRADO AL TRIGGER");
    }
}
