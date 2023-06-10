using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoVoador : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool voar = false;
    public bool moveRight = true, moveUp = true;

    private int upMove = 500;
    private int downMove = 500;

    // Update is called once per frame
    void Update()
    {
        if(voar){
            if(moveUp){
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }else{
                transform.Translate(Vector2.right * -moveSpeed * Time.deltaTime);
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("PeixeDescer")){
           // Debug.Log("colidiu com Descer");  
            moveUp = true; 
        }

        if(collision.CompareTag("PeixeSubir")){
            moveUp = false;
           // Debug.Log("colidiu com Subir");   
        }
    }

}
