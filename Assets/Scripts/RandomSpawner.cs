using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] enemyPrefab;
    int randomSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 1f);
    }

    // Update is called once per frame
    void SpawnEnemy()
    {
        randomSpawnPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab[0],spawnPoints[randomSpawnPoint].position,Quaternion.identity);
    }
}
