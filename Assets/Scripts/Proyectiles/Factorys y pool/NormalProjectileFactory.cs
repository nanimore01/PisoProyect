using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjectileFactory : MonoBehaviour
{
    public static NormalProjectileFactory Instance { get { return _instance; } }
    static NormalProjectileFactory _instance;

    public ProjectileBase projectilePrefab;
    public int stock = 10;

    public Pool<ProjectileBase> pool;

    void Start()
    {
        _instance = this;
        pool = new Pool<ProjectileBase>(ProjectileCreator, ProjectileBase.TurnOnOff, stock);
    }
    public ProjectileBase ProjectileCreator()
    {
        return Instantiate(projectilePrefab, transform);
    }

    public void ReturnProjectile(ProjectileBase p)
    {
        pool.ReturnObject(p);
    }
}
