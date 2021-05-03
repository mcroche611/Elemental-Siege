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

    public static LevelManager GetInstance() //Para conseguir la referencia a game manager haciendo gameManager.getInstance()
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

        while (puertas[cont].name.Split(' ')[1] != orientacion)
        {
            cont += 1;
        }

        player.position = puertas[cont].transform.position;
        playerTf = player;
    }

    public Transform GetPlayerTransform()
    {
        return playerTf;
    }
    
}

