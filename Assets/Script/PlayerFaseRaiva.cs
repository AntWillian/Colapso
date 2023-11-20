using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerFaseRaiva : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;

    public bool isJumping;
    public bool doubleJump;

    private Animator anim;

    private Vector3 respawnPoint;
    public GameObject falldetector;
    public GameObject fim;

    public int sanidadePlataforma;

    public bool chave;

    public AudioClip sfxDano;
    public AudioClip sfxPulo;
    public AudioController audioController;

    // variaveis para fase da Raiva
    public int redbarQtd = 0;
    public int yellowBarQtd = 0;
    public int blueBarQtd = 0;


    void Start(){
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update(){
        Move();
        Jump();
    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }

        if(Input.GetAxis("Horizontal") < 0f){
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }

        if(Input.GetAxis("Horizontal") == 0f){
            anim.SetBool("walk", false);
        }

    }

    void Jump(){
        
        if(Input.GetButtonDown("Jump") ){

            if( !isJumping){
                audioController.ToqueSFX(sfxPulo);
                rig.AddForce(new Vector2(0.5f, JumpForce), ForceMode2D.Impulse);
                anim.SetBool("jump", true);
                isJumping = true;
            }
            
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 6){
            isJumping = false;
            anim.SetBool("jump", false);
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
           // isJumping = false;
           // anim.SetBool("jump", false);
            Debug.Log("hffffit");  
        }

        if(collision.gameObject.tag == "platformYellow" ||
            collision.gameObject.tag == "platformBlue" ||
            collision.gameObject.tag == "platformRed" ||
            collision.gameObject.tag == "platform" ){
                gameObject.transform.SetParent(null);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
    
        // coletando as pilas
        if(collision.CompareTag("orbRed") ){
            redbarQtd++;
        }else if(collision.CompareTag("orbYellow") ){
            yellowBarQtd++;
        }else if(collision.CompareTag("orbBlue") ){
            blueBarQtd++;
        }    

    }


}
