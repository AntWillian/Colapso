using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] Transform[] spawnPointsSala0;
    [SerializeField] Transform[] spawnPointsSala1;
    [SerializeField] Transform[] spawnPointsSala2;
    [SerializeField] Transform[] spawnPointsSala3;
    [SerializeField] Transform[] spawnPointsSala4;
    [SerializeField] Transform[] spawnPointsSala5;
    [SerializeField] GameObject enemy;

    [SerializeField] public bool[] salas;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemies", 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnEnemies(){

        if(GameController.instance.playerIsAlive){
            //verificando qual sala o player esta
            for (int i = 0; i < salas.Length; i++) 
            {
                if(salas[i]){
                    Debug.Log("Sala "+ i);
                }          
            }

            if(salas[0]){
                int index = Random.Range(0, spawnPointsSala0.Length);
                Instantiate(enemy, spawnPointsSala0[index].position, Quaternion.identity);
            }else if(salas[1]){
                int index = Random.Range(0, spawnPointsSala1.Length);
                Instantiate(enemy, spawnPointsSala1[index].position, Quaternion.identity);
            }else if(salas[2]){
                int index = Random.Range(0, spawnPointsSala2.Length);
                Instantiate(enemy, spawnPointsSala2[index].position, Quaternion.identity);
            }else if(salas[3]){
                int index = Random.Range(0, spawnPointsSala3.Length);
                Instantiate(enemy, spawnPointsSala3[index].position, Quaternion.identity);
            }else if(salas[4]){
                int index = Random.Range(0, spawnPointsSala4.Length);
                Instantiate(enemy, spawnPointsSala4[index].position, Quaternion.identity);
            }else if(salas[5]){
                int index = Random.Range(0, spawnPointsSala5.Length);
                Instantiate(enemy, spawnPointsSala5[index].position, Quaternion.identity);
            }

        }
        

        
    }
}
