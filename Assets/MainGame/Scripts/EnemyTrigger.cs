using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    EnemyMovement enemy;
    bool playerDetected = false;

    void Start()
    {
        enemy = gameObject.GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            Debug.Log("EnemyTrigger: Player Detected");
            playerDetected = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
            playerDetected = false;
    }

    public bool DetectPlayer()
    {
        return playerDetected;
    }
}
