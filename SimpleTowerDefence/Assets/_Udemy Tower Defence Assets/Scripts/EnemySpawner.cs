using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyController enemyToSpawn;

    [SerializeField] Transform spawnPoint;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] int amountOfSpawns;

    [SerializeField] CastleController castle;
    [SerializeField] Path path;

    private float spawnCounter;
    void Start()
    {
        
    }

    void Spawning()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = timeBetweenSpawns;
            if(amountOfSpawns>0 && castle.surrendered==false)
            {
                Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation).Setup(castle,path);
                amountOfSpawns--;
            }

        }
    }
    void Update()
    {
        Spawning();
    }
}
