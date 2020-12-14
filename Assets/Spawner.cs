using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnInterval;
    float time;

    public int maxEnemies;
    public int numEnemies;

    public GameObject DemonEye;

    void Start()
    {
        numEnemies = 0;
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        Instantiate(DemonEye);
        DemonEye.transform.position = transform.position;
        numEnemies++;
    }

    void Update()
    {
        numEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (time < spawnInterval)
        {
            time += Time.deltaTime;
        }
        else
        {
            if (numEnemies < maxEnemies)
            {
                SpawnEnemy();
            }
            time = 0;
        }
    }
}
