using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class luzController : MonoBehaviour
{
    [SerializeField] float speed;
    private PlayerMove player;
    GameObject LuzColisao;

    private Light2D light2D;

    private EnergyBar usarNovaCarga;

    public Color corLuz;

    public bool poderAtivo = false;

    private int bateriaCargaTotal;

    // animacao da luz ao nao poder usar o poder
    private int contLuzAnin = 10;
    public bool animLuz = false;
    public bool cargaBaixa = false;

    //private bool usePower = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();

        usarNovaCarga = GameObject.FindGameObjectWithTag("Hud").GetComponent<EnergyBar>();

        LuzColisao = GameObject.FindGameObjectWithTag("Luz");
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        if(usarNovaCarga.cargaTotal < 2){
           
            Debug.Log("vc não mais pode usar o poder");
            PowerOff();
        }

        // usando poder
        if(Input.GetMouseButtonDown(1)){
            if(usarNovaCarga.cargaTotal < 2){
                cargaBaixa = true;
                animLuz= true;
            }
            
            Power();
        }

        if(Input.GetMouseButtonUp(1) ){
            PowerOff();
        }

        //usando carga de bateria
        if(Input.GetKeyDown(KeyCode.E)){
            cargaBateria();
        }

        // animacao da luz
        if(animLuz){
            if(contLuzAnin > 0){
                // mudando os status da luz
                light2D = LuzColisao.GetComponent<Light2D>();
                light2D.intensity = 2;
                light2D.color =Color.red;
                light2D.pointLightOuterRadius = 5;

                contLuzAnin -= 1;
            }else{
                // voltando os status da luz
                light2D = LuzColisao.GetComponent<Light2D>();
                light2D.intensity = 1;
                light2D.color =Color.white;
                light2D.pointLightOuterRadius = 4;

                 if(cargaBaixa){
                    cargaBaixa = false;
                  }

                contLuzAnin = 10;
                animLuz = false;

            }
        }            
    
    }

    void Power(){

        if(usarNovaCarga.cargaTotal > 2){
            usarNovaCarga.poderAtivado = true;
            light2D = LuzColisao.GetComponent<Light2D>();
            light2D.intensity = 2;
            light2D.color =Color.blue;
            light2D.pointLightOuterRadius = 6;

            poderAtivo = true;
            
        }else{
            animLuz = true;

            Debug.Log("vc não pode usar o poder");
        }

    }

    
    void PowerOff(){
        poderAtivo = false;

        usarNovaCarga.poderAtivado = false;
        light2D = LuzColisao.GetComponent<Light2D>();
        light2D.intensity = 1;
        light2D.color =Color.white;
        light2D.pointLightOuterRadius = 4;
        // light1.LightType.intensity = 20;
    }

    void cargaBateria(){

        if(player.pilhas <= 0){
            animLuz = true;

            Debug.Log("Vc nao possui pilhas");
        }else{
            bateriaCargaTotal = usarNovaCarga.cargaTotal;
            bateriaCargaTotal += 1;

             Debug.Log("bateria total " + bateriaCargaTotal);

            if(bateriaCargaTotal < 10){
                player.pilhas -= 1;
                usarNovaCarga.novaCarga = true;
                usarNovaCarga.animLuz = true;
                
                Debug.Log("usou uma pilha");
            }else{
                animLuz = true;
                Debug.Log("carga completa _________________________________________________");
            }
            
        }
        
    }
}
