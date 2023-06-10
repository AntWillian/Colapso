using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoVoador : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool voar = false;
    public bool moveRight = true, moveUp = true;


    // [SerializeField] Transform rotationCenter;

    // [SerializeField] float rotationRadius = .01f, angularSpeed = .01f;

    // float posX, posY, angle = 0f;


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

        // posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius / 2;
        // posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius;
        // transform.position = new Vector2(posX, posY);
        // angle = angle + Time.deltaTime * angularSpeed;

        // if(angle >= 360f){
        //     angle = 0f;
        // }

    }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("PeixeDescer")){
           // Debug.Log("colidiu com Descer");  
            gameObject.transform.localScale = new Vector3(-.4f, .4f, .4f);
            moveUp = true; 
        }

        if(collision.CompareTag("PeixeSubir")){
            gameObject.transform.localScale = new Vector3(.4f, .4f, .4f);
            moveUp = false;
           // Debug.Log("colidiu com Subir");   
        }
    }
    
}
