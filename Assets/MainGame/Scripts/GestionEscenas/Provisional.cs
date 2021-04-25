using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Provisional : MonoBehaviour
{
    public GameObject gameManager, canvas;

    void Awake()
    {
        if (GameManager.GetInstance() == null)
        {
            Instantiate<GameObject>(gameManager, transform.position, transform.rotation);
            Instantiate<GameObject>(canvas, transform.position, transform.rotation);
        }           
    }
}
