using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;
    private PlatformMove plat;

    private string Tagobj;

    public GameObject collected;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }


    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){

            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            Tagobj = gameObject.tag;

            Destroy(gameObject, 0.3f);

            if(Tagobj == "orbYellow"){
                Debug.Log("orbYellow");
               DestroyAllObjects("platformYellow");
               DestroyAllObjects("brickYellow");
            }else if(Tagobj == "orbBlue"){
                //Debug.Log("orbBlue");
              DestroyAllObjects("platformBlue");
            }else if(Tagobj == "orbRed"){
               // Debug.Log("orbRed");
                DestroyAllObjects("platformRed");
                DestroyAllObjects("brickRed");
            }
          
        }
    }


    void DestroyAllObjects(string tag){
        // Coleta os objetos
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
    
        for(var i = 0 ; i < gameObjects.Length ; i ++)
        {
            Destroy(gameObjects[i]);
        }
    }
}
