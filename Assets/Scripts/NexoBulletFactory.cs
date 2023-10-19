using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NexoBulletFactory : MonoBehaviour
{
    public static NexoBulletFactory Instance { get { return _instance; } }
    static NexoBulletFactory _instance;

    public ProyectilNexo projectilePrefab;
    public int stock = 10;

    public Pool<ProyectilNexo> pool;

    void Start()
    {
        _instance = this;
        pool = new Pool<ProyectilNexo>(ProjectileCreator, ProyectilNexo.TurnOnOff, stock);
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            ProjectileCreator();
        }*/
    }

    public ProyectilNexo ProjectileCreator()
    {
        return Instantiate(projectilePrefab);
    }

    public void ReturnProjectile(ProyectilNexo p)
    {
        pool.ReturnObject(p);
        p.speed += 0.001f;
    }
}
