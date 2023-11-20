using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barraParticulas : MonoBehaviour
{

    public Sprite[] bar;

    public Sprite[] barYellow;
    public Sprite[] barBlue;

    public Image redBar;
    public Image yellowBar;
    public Image blueBar;

    private PlayerFaseRaiva player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerFaseRaiva>();

    }

    // Update is called once per frame
    void Update()
    {
        if(player.redbarQtd > 0){
            redBar.sprite = bar[player.redbarQtd];
        }

        if(player.yellowBarQtd > 0){
            yellowBar.sprite = barYellow[player.yellowBarQtd];
        }

        if(player.blueBarQtd > 0){
            blueBar.sprite = barBlue[player.blueBarQtd];
        }
    }


}
