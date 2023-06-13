using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float speed;

    [SerializeField] GameObject particulaSanidade;
    [SerializeField] GameObject bateria;

    private PlayerMove player;

    private EnergyBar statusSanidade;


    bool isAlive = true;

    //public AudioClip sfxDano;
    public AudioController audioController;

    // variaveis de luz para detectar se o poder esta ativo
    GameObject LuzColisao;
    private luzController light2D;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();

        LuzColisao = GameObject.FindGameObjectWithTag("Luz");

        statusSanidade = GameObject.FindGameObjectWithTag("Hud").GetComponent<EnergyBar>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!player != null && isAlive){
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Luz")){
           light2D = LuzColisao.GetComponent<luzController>();
            if(light2D.poderAtivo){
                isAlive = false;
                if(statusSanidade.totalSanidade < 6){
                    // chances de dropa bateria ou sanidade
                    int chanceDeDroparBateria = Random.Range(0, 100);
                    int chanceDeDroparSanidade = Random.Range(0, 100);

                    if(chanceDeDroparBateria > chanceDeDroparSanidade){
                         //chances de droprar uma bateria
                        int bateriaDropRate = Random.Range(0, 100);
                        int chanceMinimaBateria = Random.Range(0, 100);

                        if(chanceMinimaBateria < bateriaDropRate){
                            // dropa uma bateria
                            Instantiate(bateria, gameObject.transform.position, Quaternion.identity);
                        }
                    }else{
                        //chances de droprar uma particula de sanidade
                        int sanidadeDropRate = Random.Range(0, 100);
                        int chanceMinima = Random.Range(0, 100);

                        if(chanceMinima < sanidadeDropRate){
                            // dropa uma particula de sanidade
                            Instantiate(particulaSanidade, gameObject.transform.position, Quaternion.identity);
                        }
                    }      
                }
              
                Destroy(gameObject, 0.1f);
            }
            
        }

        if(collision.CompareTag("Player")){
            isAlive = false;

           // audioController.ToqueSFX(sfxDano);
            statusSanidade.atingidaPorInimigo = true;
            Debug.Log("colidiu com player inimigo");
            Destroy(gameObject, 0.1f);
            
            
        }
    }

}
