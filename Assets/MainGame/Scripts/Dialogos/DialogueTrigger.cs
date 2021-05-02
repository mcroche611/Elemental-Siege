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

    }
}
