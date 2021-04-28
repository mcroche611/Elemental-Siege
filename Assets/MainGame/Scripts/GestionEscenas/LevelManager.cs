using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public Transform[] puertas;
    public CinemachineVirtualCamera cinemechineVirtualCamera;
    Transform playerTf;

    private void Awake()
    {
        instance = this;
    }

    public static LevelManager GetInstance() //Para conseguir la referencia a game maager haciendo gameManager.getInstance()
    {
        return instance;
    }

    public void SetUpCamera(Transform player)
    {
        cinemechineVirtualCamera.Follow = player;
    }

    public void SetUpPlayer(string orientacion, Transform player)
    {
        int cont = 0;

        while (puertas[cont].name.Split(' ')[1] != orientacion) cont += 1;
        player.position = puertas[cont].transform.position;
        playerTf = player;
    }

    //temporal para cuando no tenemos la orientacion
    public void SetPlayerTransform(Transform player)
    {
        playerTf = player;
        Debug.Log("Player Transform Position: " + player.position);
        Debug.Log("Get Transform: " + GetPlayerTransform().position);
    }

    public Transform GetPlayerTransform()
    {
        return playerTf;
    }
    
}

