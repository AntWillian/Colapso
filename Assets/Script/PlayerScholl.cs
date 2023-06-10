using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScholl : MonoBehaviour
{
   
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;

    public bool isJumping;
    public bool doubleJump;

    void Start(){
        rig = GetComponent<Rigidbody2D>();
    }

    void Update(){
        Move();
        Jump();
    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * Speed;
    }

    void Jump(){
        
        if(Input.GetButtonDown("Jump") ){

            if( !isJumping){
                rig.AddForce(new Vector2(0.5f, JumpForce), ForceMode2D.Impulse);
                isJumping = true;
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 6){
            isJumping = false;
            Debug.Log("hit");
        
        }


        if(collision.gameObject.tag == "platformYellow" ||
            collision.gameObject.tag == "platformBlue" ||
            collision.gameObject.tag == "platformRed" ||
            collision.gameObject.tag == "platform" ){
                gameObject.transform.parent = collision.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision){
         if(collision.gameObject.layer == 6){
            isJumping = true;
            Debug.Log("hffffit");

            if(collision.gameObject.tag == "platformYellow" ||
            collision.gameObject.tag == "platformBlue" ||
            collision.gameObject.tag == "platformRed" ||
            collision.gameObject.tag == "platform" ){
                //gameObject.transform.parent = collision.transform;
                gameObject.transform.SetParent(null);
        }

            
        }
    }
}


