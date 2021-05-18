using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager instance;
    public AudioSource audioSource;
    [SerializeField] AudioClip physicAttack, fireBall, botton, batDeath, slimeDeath, waterBall, electricBall;
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
    public static SoundManager GetInstance()
    {
        return instance;
    }
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void physicAttackSound()
    {
        audioSource.clip = physicAttack;
        audioSource.Play();
    }
    public void bottonSound()
    {
        audioSource.clip = botton;
        audioSource.Play();
    }
    public void batDeathSound()
    {
        audioSource.clip = batDeath;
        audioSource.Play();
    }
    public void slimeDeathSound()
    {
        audioSource.clip = slimeDeath;
        audioSource.Play();
    }
    public void fireBallSound()
    {
        audioSource.clip = fireBall;
        audioSource.Play();
    }
    public void waterBallSound()
    {
        audioSource.clip = waterBall;
        audioSource.Play();
    }
    public void electricBallSound()
    {
        audioSource.clip = electricBall;
        audioSource.Play();
    }
}


