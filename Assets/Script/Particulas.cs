using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particulas : MonoBehaviour
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

            Debug.Log("colidiu com o player");  
            //Tagobj.redbarQtd ++;
          
    
          
        }
    }

}
