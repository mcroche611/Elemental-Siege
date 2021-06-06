using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            DialogueManager.GetInstance().StartDialogue();
            Destroy(gameObject);
        }
        
    }
}
