using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void MenuPlayGame()
    {
        // deleta variaveis globais
        PlayerPrefs.DeleteKey("p_x");
        PlayerPrefs.DeleteKey("p_y");
        PlayerPrefs.DeleteKey("TimeToLoad");
        PlayerPrefs.DeleteKey("Saved");
        PlayerPrefs.DeleteKey("FaseEscola");
        PlayerPrefs.DeleteKey("FasePonte");


        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Vai come�ar");
    }

    public void MenuQuitGame()
    {
        Application.Quit();
        Debug.Log("Vai Fechar");
    }

}
