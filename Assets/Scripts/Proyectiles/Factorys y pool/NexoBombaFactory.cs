using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NexoBombaFactory : MonoBehaviour
{
    public static NexoBombaFactory Instance { get { return _instance; } }
    static NexoBombaFactory _instance;

    public ProyectilNexoBomba projectilePrefab;
    public int stock = 10;

    public Pool<ProyectilNexoBomba> pool;

    void Start()
    {
        _instance = this;
        pool = new Pool<ProyectilNexoBomba>(ProjectileCreator, ProyectilNexoBomba.TurnOnOff, stock);
    }

    public ProyectilNexoBomba ProjectileCreator()
    {
        return Instantiate(projectilePrefab, transform);
    }

    public void ReturnProjectile(ProyectilNexoBomba p)
    {
        pool.ReturnObject(p);
        p.speed += 0.001f;
    }
}
