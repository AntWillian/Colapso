using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public GameObject gameOver;

    public GameObject showStartGame;

    public static GameController instance;

    ///// VARIAVEL QUE VERIFICA SE O GAME FOI STARTADO
    public bool gameStart = false;

    // Verifica se Player esta vivo
    public bool playerIsAlive = true;

    ///// VARIAVEL QUE verifica quantas vezes o player pode reniciar a fase
    public int reniciarGameVidas = 11;

    // ativa todos os spawner de inimigos
    //public bool ativarAllSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOver(){
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName){

        SceneManager.LoadScene(lvlName);
    }

    public void RestartGameFarol(string lvlName){
        reniciarGameVidas -= 1 ;
       //(reniciarGameVidas + "VIDAS RESTANTES");
        SceneManager.LoadScene(lvlName);
    }

    public void nextFaseFarol(string lvlName){
        SceneManager.LoadScene(lvlName);
    }

    public void startGame(string lvlName){
        //SceneManager.LoadScene(lvlName);
       // Debug.Log("RERERERERERERREREERREREER");
        showStartGame.SetActive(false);
    }

}
