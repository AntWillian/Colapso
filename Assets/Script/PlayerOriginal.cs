using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerOriginal : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    // Vector2 moveInput;
    public Animator anim;
    public float speed;

    SavePlayerPos playerPosData;

    public AudioClip footstepSound; // Som de passos
    private AudioSource audioSource;

    void Start()
    {

        audioSource = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>();

        //audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
        playerPosData.PlayerPosLoad();
    }

    // Update is called once per frame
    void Update()
    {

        if (dialogueUI.IsOpen) return;


        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0f);
        
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime;

         // Verifica se o jogador está se movendo e toca o som de passos
        if (movement.magnitude > 0)
        {
            Debug.Log( " Sala 000000fbdgdg00");
            PlayFootstepSound();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Interactable?.Interact(this);
        }
    }

    
    void PlayFootstepSound()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(footstepSound);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.gameObject.tag == "EntradaEscola"){

            if (PlayerPrefs.GetInt("FaseEscola") == 0){
                playerPosData = FindObjectOfType<SavePlayerPos>();
                playerPosData.PlayerPosSave();

                SceneManager.LoadScene("faseSchool");    
            }else{
                Debug.Log("Fase Completa");
            }
            
        } 

        if( collision.gameObject.tag == "EntradaPonte"){
         
            if (PlayerPrefs.GetInt("FaseEscola") == 1){
                playerPosData = FindObjectOfType<SavePlayerPos>();
                playerPosData.PlayerPosSave();

                SceneManager.LoadScene("FasePonte");    
            }else{
                Debug.Log("Fase Completa PONTE");
            }
            
        } 

        if( collision.gameObject.tag == "EntradaFarol"){
         
            if (PlayerPrefs.GetInt("FasePonte") == 1){
                playerPosData = FindObjectOfType<SavePlayerPos>();
                playerPosData.PlayerPosSave();

                SceneManager.LoadScene("FaseFarolLevel1");    
            }else{
                Debug.Log("Fase Completa Farol");
            }
            
        } 


        
    }
    

    
}
