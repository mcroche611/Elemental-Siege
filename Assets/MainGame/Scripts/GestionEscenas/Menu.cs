using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject creditos;
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
}
