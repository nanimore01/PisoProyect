using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public EnemigoBase[] enemigos;

    
    void Start()
    {
        int NumeroRandom = Random.Range(0, enemigos.Length);

        Instantiate(enemigos[NumeroRandom],transform.position,Quaternion.Euler(90,0,0));
    }

    
}
