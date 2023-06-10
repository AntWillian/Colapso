using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;

    public bool isJumping;
    public bool doubleJump;

    private Animator anim;

    private Vector3 respawnPoint;
    public GameObject falldetector;

    public int sanidadePlataforma;

    public bool chave;


    void Start(){
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        respawnPoint = transform.position;
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
        if(collision.CompareTag("LinhaFinal")){
            Debug.Log("colidiu com a linha final");  

            sanidadePlataforma--;
            transform.position = respawnPoint;
        }else if(collision.CompareTag("CheckPoint")){
            respawnPoint = transform.position;
        }else if(collision.CompareTag("InimigoPeixe")){
            sanidadePlataforma--;
        }else if(collision.CompareTag("Key")){
             //coletandoPilha.animText = true;
            Destroy(collision.gameObject);
            chave = true;
        }else if(collision.CompareTag("Porta")){
             //coletandoPilha.animText = true;
            if(chave){
                chave = false;
                GameController.instance.nextFaseFarol("FaseFarolLevel2");
            }
            
        }else if(collision.CompareTag("Porta2")){
             //coletandoPilha.animText = true;
            if(chave){
                chave = false;
                GameController.instance.nextFaseFarol("FaseFarolLevel3");
            }
            
        }else if(collision.CompareTag("Porta3")){
             //coletandoPilha.animText = true;
            if(chave){
                chave = false;
                GameController.instance.nextFaseFarol("FinalLevel");
            }
            
        }

        if(sanidadePlataforma == 0){
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }

    }


}
