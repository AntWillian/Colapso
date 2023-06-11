using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePlayerPos : MonoBehaviour
{

    public GameObject player;
    void Start()
    {
        if (PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") == 1)
        {
            float pX = player.transform.position.x;
            float pY = player.transform.position.y;

            pX = PlayerPrefs.GetFloat("p_x");
            pY = PlayerPrefs.GetFloat("p_y");

            if (PlayerPrefs.GetInt("FasePonte") == 1){
                player.transform.position = new Vector2(-1.98f, 19.52f);
            }else{
                player.transform.position = new Vector2(pX, (pY-2));
            }
            

            PlayerPrefs.SetInt("TimeToLoad", 0);
            PlayerPrefs.Save();
        }

       
    }

    public void PlayerPosSave(){
        PlayerPrefs.SetFloat("p_x", player.transform.position.x );
        PlayerPrefs.SetFloat("p_y", player.transform.position.y );
        PlayerPrefs.SetInt("Saved", 1);
        PlayerPrefs.Save();
    }

    public void PlayerPosLoad(){
        PlayerPrefs.SetInt("TimeToLoad", 1);
        PlayerPrefs.Save();
    }


}
