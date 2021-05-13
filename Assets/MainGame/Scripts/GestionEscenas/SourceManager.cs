using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip playerWalking;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void playerWalkungSound()
    {
        audioSource.clip = playerWalking;
        audioSource.Play();
    }
}
