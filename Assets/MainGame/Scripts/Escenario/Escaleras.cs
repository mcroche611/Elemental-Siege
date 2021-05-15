using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escaleras : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            Destroy(collision.gameObject);
            LevelManager.GetInstance().FinNivel();
            SceneManager.LoadScene("3P0");
        }
    }
}
