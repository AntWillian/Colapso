using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void MenuPlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Vai come�ar");
    }

    public void MenuQuitGame()
    {
        Application.Quit();
        Debug.Log("Vai Fechar");
    }

}
