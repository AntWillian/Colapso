using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    // [SerializeField] float moveSpeed;
    // Vector2 moveInput;
    public Animator anim;
    public float speed;

    public int pilhas;
    public int vidas;

    private EnergyBar coletandoPilha;

    private SpawnManager salaSpawm;

    public AudioClip footstepSound; // Som de passos
    private AudioSource audioSource;

    void Start()
    {

        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();

        //audioSource = GetComponent<AudioSource>();
    }

    

    // Update is called once per frame
    void Update()
    {

        coletandoPilha = GameObject.FindGameObjectWithTag("Hud").GetComponent<EnergyBar>();

        salaSpawm = GameObject.FindGameObjectWithTag("Spawns").GetComponent<SpawnManager>();


        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0f);
        
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;

        // Verifica se o jogador está se movendo e toca o som de passos
        if (movement.magnitude > 0)
        {
            Debug.Log( " Sala rwrwerwerwerwer");
            PlayFootstepSound();
        }

    }

    void PlayFootstepSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(footstepSound);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){

        // coletando as pilas
        if(collision.gameObject.tag == "Pilha"){

            coletandoPilha.animText = true;
            Destroy(collision.gameObject);
            pilhas++;
        }      

    }

    private void OnTriggerEnter2D(Collider2D collision){

        if( collision.gameObject.tag == "SaidaEscola"){
            GameController.instance.salvaFaseEscola();
            SceneManager.LoadScene("MapaPrincipal1");    
        } 

        // SALA 0 e saida das salas
       if(collision.gameObject.tag == "SalaExit"){         
            for (int i = 0; i < salaSpawm.salas.Length; i++){
                if(salaSpawm.salas[i]){
                    salaSpawm.salas[i] = false;
                }          
            }
        
        } 

         // SALA 1
        if( collision.gameObject.tag == "Sala0"){
            GameController.instance.gameStart = true;
            salaSpawm.salas[0] = true;
           // Debug.Log(salaSpawm.salas[0] + " Sala 00000000");

        } 

        // SALA 1
        if( collision.gameObject.tag == "Sala1Enter"){
            salaSpawm.salas[1] = true;
          //  Debug.Log(salaSpawm.salas[1] + " Sala 111111");

        } 

         // SALA 2
        if( collision.gameObject.tag == "Sala2Enter"){
            salaSpawm.salas[2] = true;
           // Debug.Log(salaSpawm.salas[2] + " Sala 222222222");
        } 

         // SALA 3
        if( collision.gameObject.tag == "Sala3Enter"){
            salaSpawm.salas[3] = true;
           // Debug.Log(salaSpawm.salas[3] + " Sala 3333333333");

        } 

         // SALA 4
        if( collision.gameObject.tag == "Sala4Enter"){          
            salaSpawm.salas[4] = true;
           // Debug.Log(salaSpawm.salas[4] + " Sala 444444444");

        } 

         // SALA 5
        if( collision.gameObject.tag == "Sala5Enter"){
            salaSpawm.salas[5] = true;
           // Debug.Log(salaSpawm.salas[5] + " Sala 555555555");

        } 

         // SALA 6
        if(collision.gameObject.tag == "Sala6Enter"){
            salaSpawm.salas[6] = true;
           // Debug.Log(salaSpawm.salas[6] + " Sala 666666666666");

        } 

         // SALA 7
        if(collision.gameObject.tag == "Sala7Enter"){
            salaSpawm.salas[7] = true;
           // Debug.Log(salaSpawm.salas[7] + " Sala 777777777");
        } 

         // SALA 8
        if(collision.gameObject.tag == "Sala8Enter"){ 
            salaSpawm.salas[8] = true;
          //  Debug.Log(salaSpawm.salas[8] + " Sala 888888888");
        } 

         // SALA 9
        if(collision.gameObject.tag == "Sala9Enter"){
            salaSpawm.salas[9] = true;
           // Debug.Log(salaSpawm.salas[9] + " Sala 9999999999");
        } 

         // SALA 10
        if(collision.gameObject.tag == "Sala10Enter"){
            salaSpawm.salas[10] = true;
           // Debug.Log(salaSpawm.salas[10] + " Sala 10000000000000");
        }

         
    }

    
}
