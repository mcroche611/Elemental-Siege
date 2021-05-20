using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static SoundManager instance;
    public AudioSource audioSource;
    [SerializeField] AudioClip physicAttack, fireBall, botton, waterBall, electricBall, openDoor, closeDoor, llamarSoldados, charco, jarronBreak, renacer, curar, playerDeath,escalera;
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
    public void openDoorSound()
    {
        audioSource.clip = openDoor;
        audioSource.Play();
    }
    public void closeDoorSound()
    {
        audioSource.clip = closeDoor;
        audioSource.Play();
    }
    public void jarronBreakSound()
    {
        audioSource.clip = jarronBreak;
        audioSource.Play();
    }
    public void renacerSound()
    {
        audioSource.clip = renacer;
        audioSource.Play();
    }
    public void curarSound()
    {
        audioSource.clip = curar;
        audioSource.Play();
    }
    public void llamarSoldadosSound()
    {
        audioSource.clip = llamarSoldados;
        audioSource.Play();
    }
    public void playerDeathSound()
    {
        audioSource.clip = playerDeath;
        audioSource.Play();
    }
    public void escaleraSound()
    {
        audioSource.clip = escalera;
        audioSource.Play();
    }
    public void charcoSound()
    {
        audioSource.clip = charco;
        audioSource.Play();
    }
}


