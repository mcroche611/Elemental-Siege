using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceManager : MonoBehaviour
{
    static SourceManager instance;
    public AudioSource audioSource;
    [SerializeField] AudioClip playerWalking, botton;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static SourceManager GetInstance()
    {
        return instance;
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void playerWalkungSound()
    {
        audioSource.clip = playerWalking;
        audioSource.Play();
    }
    public void bottonSound()
    {
        audioSource.clip = botton;
        audioSource.Play();
    }
}
