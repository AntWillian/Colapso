using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool platform1 = false;
    public bool platform2 = false;
    public bool moveRight = true, moveUp = true;

    private int rightMove = 200;
    private int leftMove = 200;

    private int upMove = 200;
    private int downMove = 200;
    


    // Update is called once per frame
    void Update()
    {
        if(platform1){
            if(rightMove >= 0){
                moveRight = false;
                rightMove -= 1;
            }else if(leftMove >= 0){
                moveRight = true;
                leftMove -= 1;
            }else{
                rightMove = 200;
                leftMove = 200;
            }
                

            if(moveRight){
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }else{
                transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);

            }
        }

         if(platform2){
             if(upMove >= 0){
                moveUp = false;
                upMove -= 1;
            }else if(downMove >= 0){
                moveUp = true;
                downMove -= 1;
            }else{
                upMove = 200;
                downMove = 200;
            }
               

            if(moveUp){
                transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            }else{
                transform.Translate(Vector2.up * -moveSpeed * Time.deltaTime);

            }
        }
    }

    

   
}
