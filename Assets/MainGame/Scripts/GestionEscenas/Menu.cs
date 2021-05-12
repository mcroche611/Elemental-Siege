using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool gamePaused;
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //&& !DialogueManager.GetInstance().DialogueGoing());

        {
            if (Time.timeScale == 1f)
            {
                Pause();
                /*
                 if (Input.GetMouseButtonDown(0))
                {
                    MainMenu();
                }
                */
                
            }
            else
            {
                Resume();
            }
        }

    }
    //Método público para cambiar de escena
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }
    public void MainMenu()
    {
        gamePaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public bool GamePaused()
    {
        return gamePaused;
    }
}
