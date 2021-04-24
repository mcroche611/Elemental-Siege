using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Provisional : MonoBehaviour
{
    public GameObject gameManager;

    void Start()
    {
        if (GameManager.GetInstance() == null)
            Instantiate<GameObject>(gameManager, transform.position, transform.rotation);
    }
}
