using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{

    public Sprite[] bar;
    public Sprite[] bateria;
    public Image energyBar;
    public Image bateriaCarga;

    public TMP_Text pilhaColetadas;
    
   
    // total de pontos de sanidade
    public int totalSanidade;

    // tempo para a sanidade cair um ponto

    private float tempoUnidadeSanidade = 8;
    private float tempoTotalSanidade = 8;

    // sinaliza que uma particula de sanidade foi coletada
    public bool sanidadeColetada = false;

    //Sinaliza que a personagem tomou dano
    public bool atingidaPorInimigo = false;

    // animacao da luz a ser usado uma nova bateria ou coletar uma sanidade
    GameObject LuzColisaoSanidade;
    private Light2D light2DSanidade;
    private int contLuzAninSanidade = 10;
    public bool animLuzSanidade = false;

    // ############### BATERIAS ########################

   
    public int cargaDeBateria;


    // carga total da bateria
    public int cargaTotal=9;

    // animacao do texto ao coletar nova pilha
    private int contTextAnin = 10;
    public bool animText = false;

    // animacao da luz a ser usado uma nova bateria ou coletar
    GameObject LuzColisao;
    private Light2D light2D;
    private int contLuzAnin = 10;
    public bool animLuz = false;

    // TEMPO para gastar uma unidade da bateria
    private float tempoTotalbateria = 5;
    private float tempoUnidadeBateria = 5;
    private float tempoUnidadeBateriaPoder = 5 ;

    // sinaliza que uma bateria foi usada
    public bool novaCarga = false;

    // sinaliza que o poder foi ativado e usa a bateria mais rapido
    public bool poderAtivado = false;

    private PlayerMove player;

   


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();

        LuzColisao = GameObject.FindGameObjectWithTag("Luz");
        
        LuzColisaoSanidade = GameObject.FindGameObjectWithTag("Luz");
    }

    // Update is called once per frame
    void Update()
    {
        ///// VARIAVEL QUE VERIFICA SE O GAME FOI STARTADO
        if(GameController.instance.gameStart){

            //########### COLETA DE PONTOS DE SANIDADE ##############################################################################

                if(sanidadeColetada){
                    // animacao da luz
                    if(animLuzSanidade){
                        if(contLuzAninSanidade > 0){

                            // mudando os status da luz
                            light2DSanidade = LuzColisaoSanidade.GetComponent<Light2D>();
                            light2DSanidade.intensity = 2;
                            light2DSanidade.color = Color.yellow;
                            light2DSanidade.pointLightOuterRadius = 5;

                            contLuzAninSanidade -= 1;
                        }else{
                            // voltando os status da luz
                            light2DSanidade = LuzColisaoSanidade.GetComponent<Light2D>();
                            light2DSanidade.intensity = 1;
                            light2DSanidade.color = Color.white;
                            light2DSanidade.pointLightOuterRadius = 4;

                            contLuzAninSanidade = 10;
                            animLuzSanidade = false;

                            // verifica se a carga total esta cheia
                            if(totalSanidade < 11){
                                // adiciona nova carga a sanidade e muda o visual 
                                totalSanidade += 1;
                                energyBar.sprite = bar[totalSanidade];
                                tempoUnidadeSanidade = tempoTotalSanidade;

                                // setando o fim do uso da coleta
                                sanidadeColetada = false;
                            }else{
                                Debug.Log("sanidade FULLLLLLLLLLLLL");
                            }
                            
                        }
                    }
                }

                // Animaçao de dano 

                if(atingidaPorInimigo){
                    // tira uma carga da sanidade e muda o visual 
                    totalSanidade -= 1;
                    energyBar.sprite = bar[totalSanidade];
                    tempoUnidadeSanidade = tempoTotalSanidade;

                    // seta que ja tomou o dano
                    atingidaPorInimigo = false;
                }

                if(totalSanidade > 0){
                    if(tempoUnidadeSanidade <= 0 ){
                        totalSanidade -= 1;
                        energyBar.sprite = bar[totalSanidade];

                    // Debug.Log("carga total da sanidade  "+totalSanidade );
                        tempoUnidadeSanidade = tempoTotalSanidade;

                    }else{
                        tempoUnidadeSanidade -= Time.deltaTime;
                    }
                }else{
                    GameController.instance.playerIsAlive = false;
                    GameController.instance.ShowGameOver();
                    Destroy(player.gameObject);
                }

       
        

            //########### COLETA DE PILHAS ##############################################################################
                // texto da quantidade de baterias
                pilhaColetadas.text =player.pilhas.ToString();

                // animacao do texto
                if(animText){
                    if(contTextAnin > 0){
                        pilhaColetadas.fontSize += 1;
                        contTextAnin -= 1;
                    }else{
                        pilhaColetadas.fontSize = 28;
                        contTextAnin = 10;
                        animText = false;
                    }
                }
            

                //energyBar.sprite = bar[player.pilhas];
                //energyBar.sprite = bar[8];
                //bateriaCarga.sprite = bateria[3];
                
                // bateria sendo usada
                if(novaCarga){
                    // animacao da luz
                    if(animLuz){
                        if(contLuzAnin > 0){

                            // mudando os status da luz
                            light2D = LuzColisao.GetComponent<Light2D>();
                            light2D.intensity = 2;
                            light2D.color = Color.green;
                            light2D.pointLightOuterRadius = 5;

                            contLuzAnin -= 1;
                        }else{
                            // voltando os status da luz
                            light2D = LuzColisao.GetComponent<Light2D>();
                            light2D.intensity = 1;
                            light2D.color = Color.white;
                            light2D.pointLightOuterRadius = 4;

                            contLuzAnin = 10;
                            animLuz = false;

                            // adiciona nova carga e muda o visual 
                            cargaTotal += 1;
                            bateriaCarga.sprite = bateria[cargaTotal];
                            tempoUnidadeBateria = tempoTotalbateria;

                            // setando o fim do uso da carga
                            novaCarga = false;

                        }
                    }
                    //Debug.Log("nova bateria usada heheheheheheheheheheh");
                }

                if(!poderAtivado){
                    if(cargaTotal > 0){
                        if(tempoUnidadeBateria <= 0 ){
                            cargaTotal -= 1;
                            bateriaCarga.sprite = bateria[cargaTotal];

                            //Debug.Log("carga bateria total "+cargaTotal );
                            tempoUnidadeBateria = tempoTotalbateria;

                        }else{
                            tempoUnidadeBateria -= Time.deltaTime;
                        }
                    }else{
                    //  Debug.Log("Fim da carga");
                    }
                }else{
                    Debug.Log("HERERERERERER");
                    if(cargaTotal > 0){
                        if(tempoUnidadeBateriaPoder <= 0 ){
                            cargaTotal -= 1;
                            bateriaCarga.sprite = bateria[cargaTotal ];
                            tempoUnidadeBateriaPoder = (tempoTotalbateria/2);
                        }else{
                            tempoUnidadeBateriaPoder -= Time.deltaTime;
                        }
                    }else{
                        Debug.Log("Fim da carga usando x2 eeeeeeeeeeee");
                    }
                }
                
        }  

    }
}
