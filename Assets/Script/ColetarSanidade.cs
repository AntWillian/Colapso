using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetarSanidade : MonoBehaviour
{

    private EnergyBar coletarSaniade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coletarSaniade = GameObject.FindGameObjectWithTag("Hud").GetComponent<EnergyBar>();

    }


    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            Debug.Log("colidiu com player");
            coletarSaniade.sanidadeColetada = true;
            coletarSaniade.animLuzSanidade = true;
            Destroy(gameObject, 0.1f);
                
        }
    }
}
