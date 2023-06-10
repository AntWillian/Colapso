using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BarraDeSanidade : MonoBehaviour
{

    public Sprite[] bar;
    public Image energyBar;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {

        if(player.sanidadePlataforma > 0){
            energyBar.sprite = bar[player.sanidadePlataforma];
        }
        
    }
}
