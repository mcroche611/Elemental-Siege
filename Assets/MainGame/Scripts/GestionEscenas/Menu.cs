using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject creditos;
    public GameObject optionPanel;
    public void ChangeScene(string sceneName)
    {
        SoundManager.GetInstance().bottonSound();
        SceneManager.LoadScene(sceneName);
    }
    
    public void QuitGame()
    {
        SoundManager.GetInstance().bottonSound();
        Application.Quit();
    }

    public void Retry()
    {
        LevelManager.GetInstance().PrimeraHabitacion();
    }

    public void BackToMenu()
    {
        GameManager.GetInstance().ResetBonos();
        LevelManager.GetInstance().FinNivel();
        ChangeScene("Menu");
    }

    public void OcultarMostrarCreditos(bool b)
    {
        creditos.SetActive(b);
    }
    public void optionButton()
    {
        optionPanel.SetActive(true);
    }
    public void backButton()
    {
        optionPanel.SetActive(false);
    }
    public void setVolume(float value)
    {
        audioMixer.SetFloat("BGMVolume", value);
    }
}
