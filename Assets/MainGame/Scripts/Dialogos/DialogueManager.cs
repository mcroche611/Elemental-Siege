using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager instance;
   

    private void Awake()
    {
        instance = this;
    }

    public static DialogueManager GetInstance() //Para conseguir la referencia a game manager haciendo gameManager.getInstance()
    {
        return instance;
    }

    [SerializeField]
    string[] dialogueSentences;

    public void ActivarPanel()
    {
        gameObject.SetActive(true);
    }
}
