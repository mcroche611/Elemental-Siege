using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            DialogueManager.GetInstance().StartDialogue();
            Debug.Log("ENTRADO AL TRIGGER");
            Destroy(gameObject);
        }
        
    }
}
