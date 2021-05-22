using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

using UnityEngine;

public class PausaMenu : MonoBehaviour
{
    static PausaMenu instance;
    bool gamePaused;
    public GameObject pauseMenu;
    public GameObject controles;

    void Awake()
    {
        //Si no hay ninguna instancia creada almacenamos aqui la instancia actual
        if (instance == null)
        {
            instance = this;
            //Nos aseguramos de que el objeto al que esta asociado este script no se destruira al cambiar de escena
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Si ya existe un gameobject con un componente instancia de esta clase (es decir ya hay un GM) no necesitamos uno nuevo
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        GameManager.GetInstance().SetPauseMenu(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //&& !DialogueManager.GetInstance().DialogueGoing());
        {
            if (Time.timeScale == 1f)
                Pause();
            else if (DialogueManager.GetInstance().DialogueGoing() == false)
                Resume();
        }
    }

    public void Pause()
    {
        SoundManager.GetInstance().bottonSound();
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }

    public void Resume()
    {
        SoundManager.GetInstance().bottonSound();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void MainMenu()
    {
        SoundManager.GetInstance().bottonSound();
        gamePaused = false;
        Time.timeScale = 1f;
        if (LevelManager.GetInstance() != null)
            LevelManager.GetInstance().FinNivel();
        else Destroy(GameManager.GetInstance().GetPlayer());
        Destroy(this.gameObject);
        GameManager.GetInstance().GMDestruirCanvas();
        GameManager.GetInstance().ResetBonos();
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    public void OcultarMostrarControles(bool b)
    {
        GameManager.GetInstance().GMOcultarMostrarCanvas(!b);
        pauseMenu.SetActive(!b);
        controles.SetActive(b);
    }

    public bool GamePaused()
    {
        return gamePaused;
    }

}
