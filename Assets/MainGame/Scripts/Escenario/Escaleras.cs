using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escaleras : MonoBehaviour
{
    [SerializeField] string escena;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>() != null)
        {
            SoundManager.GetInstance().electricBallSound();
            Destroy(collision.gameObject);
            LevelManager.GetInstance().FinNivel();
            SceneManager.LoadScene(escena);
        }
    }
}
