using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int round = 1;
    public int zombiesInRound = 6;
    public int zombiesSpawnedInRound = 0;
    float zombieSpawnTimer =0;
    public Transform[] zombieSpawnPoints;
    
    void Start()
    {
        
    }
    void FixedUpdate()
    { 
        if(zombiesSpawnedInRound < zombiesInRound) 
            { 
                if (zombieSpawnTimer > 30) 
                {
                    SpawnZombie();
                    zombieSpawnTimer=0;
                }
                else { zombieSpawnTimer++; }
            }
    }

    void SpawnZombie()
    {

    }
}
