using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool platform1 = false;
    public bool platform2 = false;

    public float timerMovePlatform;
    

    // variavel de tempo para movimentacao ponte
    private float timerMove;
    private float timerMoveUp;
    public bool moveRight = false;
    public bool moveUp = false;

    void Start()
    {
        timerMove = 3f;

        timerMovePlatform = timerMovePlatform;

        Debug.Log( "STARTTTTT timerMove=" + timerMove);
        Debug.Log( "STARTTTTT timerMovePlatform=" + timerMovePlatform);
    }


    // Update is called once per frame
    void Update(){
       
            if(timerMove <= timerMovePlatform && moveRight){
                moveRight = true;
                timerMove = timerMove + Time.deltaTime;

              //  Debug.Log( "true dddd timerMove=" + timerMove);
            }else{

                if(timerMove >= 0){
                    moveRight = false;
                    timerMove = timerMove - Time.deltaTime;
                   // Debug.Log( "False timerMove=" + timerMove);
                }else{
                    timerMove = 0;
                    moveRight = true;
                }
               
            }

          

            if(platform1){

                if(moveRight){
                    transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
                }else{
                    transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);
                }

            }else if(platform2){

                if(moveRight){
                    transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
                }else{
                    transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);
                }
                
            }
        }
}

