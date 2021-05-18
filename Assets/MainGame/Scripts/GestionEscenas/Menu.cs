using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //Método público para cambiar de escena
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


}
