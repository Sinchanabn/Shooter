using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //Enemy Prefab
    public GameObject Enemy;

    float maxSpawnRateInSeconds = 5f;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", maxSpawnRateInSeconds);

        //Increasing the SpawnRate Every 30 secs

        InvokeRepeating("IncreaseSpawnRate", 0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Method to spwan the enemy randamly

    void SpawnEnemy()
    {
        //Buttom left point of the screen
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        //Top Right point of the screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        // Instantiating the Enemy
        GameObject anEnemy = (GameObject)Instantiate(Enemy);
        anEnemy.transform.position = new Vector2 (Random.Range(min.x, max.x),max.y);

        //Calling next Enemy Spwan
        NextEnemSpwan();

    }

    //Method to call Next enemy Spawn
    void NextEnemSpwan()
    {
        float spawnInSeconds;
        if (maxSpawnRateInSeconds > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
            spawnInSeconds = 1f;
        
        Invoke("SpawnEnemy", spawnInSeconds);

    }

    //Method to increas Spawn rate
    void IncreaseSpawnRate()
    {
        if (maxSpawnRateInSeconds > 1f)
            maxSpawnRateInSeconds--;
        if (maxSpawnRateInSeconds == 1f)
            CancelInvoke("IncreaseSpawnRate");
    }
}
