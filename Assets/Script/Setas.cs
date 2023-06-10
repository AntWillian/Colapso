using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setas : MonoBehaviour
{
    private SpriteRenderer sr;
    private BoxCollider2D circle;
    private PlatformMove plat;

    private string Tagobj;

    public GameObject collected;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<BoxCollider2D>();
    }


    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){

            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            Tagobj = gameObject.tag;

            Destroy(gameObject, 0.3f);

            if(Tagobj == "setaUpYellow"){
               DestroyAllObjects("platformYellow");
            }else if(Tagobj == "setaUpBlue"){
              DestroyAllObjects("platformBlue");
            }else if(Tagobj == "setaUpRed"){
                DestroyAllObjects("platformRed");
            }
          
        }
    }


    void DestroyAllObjects(string tag){
        // Coleta os objetos
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);

        for(var i = 0 ; i < gameObjects.Length ; i ++)
        {
            GameObject platMove = gameObjects[i];

            plat = platMove.GetComponent<PlatformMove>();

            Debug.Log(plat.platform2 = true);
        }
    }
}
