using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDeBalas : MonoBehaviour
{
    private int _balaIndex;
    public ProyectilNexo[] balas;
    public Transform xRangeLeft, xRangeRight, yRangeUp, yRangeDown;
    public float timeSpawn, repeatSpawnRate;
    

    void Start()
    {

        

        
        
    }


    void Update()
    {
        repeatSpawnRate += Time.deltaTime;

        if (repeatSpawnRate > timeSpawn)
        {
            SpawnEnemies();
            repeatSpawnRate = 0;
        }
    }

    public void SpawnEnemies()
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0);

        spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);
        var p = NexoBulletFactory.Instance.pool.GetObject();
        p.transform.position = spawnPosition;
        

    }

   
}
