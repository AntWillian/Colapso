using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarraDeReinicio : MonoBehaviour
{

    public Sprite[] bar;
    public Image energyBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.reniciarGameVidas > 0){
            energyBar.sprite = bar[GameController.instance.reniciarGameVidas];
        }
    }
}
