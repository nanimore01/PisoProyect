using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDeBalas : MonoBehaviour
{
    
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
        int Probabilidad = Random.Range(0, 101);

        spawnPosition = new Vector3(Random.Range(xRangeLeft.position.x, xRangeRight.position.x), Random.Range(yRangeDown.position.y, yRangeUp.position.y), 0);
        var p = NexoBulletFactory.Instance.pool.GetObject();
        var b = NexoBombaFactory.Instance.pool.GetObject();

       
        if(Probabilidad > 20)
        {
            p.transform.parent = NexoBulletFactory.Instance.transform;
            p.transform.position = spawnPosition;
        }
        else if(Probabilidad < 20)
        {
            b.transform.parent = NexoBombaFactory.Instance.transform;
            b.transform.position = spawnPosition;
        }
        

    }

   
}
