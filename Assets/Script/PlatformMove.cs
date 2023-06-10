using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool platform1 = false;
    public bool platform2 = false;
    

    // variavel de tempo para movimentacao ponte
    private float timerMove;
    private float timerMoveUp;
    public static bool moveRight = false;
    public bool moveUp = true;

    


    // Update is called once per frame
    void Update()
    {
        if(platform1){

            if( timerMove <= 2 && moveRight){
                moveRight = true;
                timerMove = timerMove + Time.deltaTime;

                Debug.Log( "true dddd timerMove=" + timerMove);
            }else{

                if(timerMove >= 0){
                    moveRight = false;
                    timerMove = timerMove - Time.deltaTime;
                    Debug.Log( "False timerMove=" + timerMove);
                }else{
                    moveRight = true;
                }
               
            }


            if(moveRight){
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }else{
                transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);

            }
        }

         if(platform2){

            if( timerMoveUp <= 2 && moveRight){
                moveUp = true;
                timerMoveUp = timerMoveUp + Time.deltaTime;

                Debug.Log( "true dddd timerMoveUp=" + timerMoveUp);
            }else{

                if(timerMoveUp >= 0){
                    moveUp = false;
                    timerMoveUp = timerMoveUp - Time.deltaTime;
                    Debug.Log( "False timerMoveUp=" + timerMoveUp);
                }else{
                    moveUp = true;
                }
               
            }
               

            if(moveUp){
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }else{
                transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);

            }
        }
    }

    

   
}
