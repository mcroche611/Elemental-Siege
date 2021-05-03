using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameManager pauseMenu;
    
    //Método público para cambiar de escena
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
    }
}
