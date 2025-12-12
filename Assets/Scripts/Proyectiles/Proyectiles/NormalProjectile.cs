using UnityEngine;

public class NormalProjectile : ProjectileBase
{
    public override void Awake()
    {
        base.Awake();
        collisionBeheviour.AddListener(KillPlayer);
    }
    public override void ReturnProyectile()
    {
        NormalProjectileFactory.Instance.ReturnProjectile(this);
    }

    

    //public static void TurnOnOff(ProjectileBase p, bool active = true)
    //{
    //    if (active)
    //    {
    //        p.Reset();
    //    }
    //    p.gameObject.SetActive(active);
    //}

    //public void Reset()
    //{
    //    _timer.Reset();
    //    _timer.Start();
    //}
    public override void SpawnProyectile(Transform transform)
    {
        var p = NormalProjectileFactory.Instance.pool.GetObject();
        p.transform.SetPositionAndRotation(transform.position, transform.rotation.normalized);
    }

    public void KillPlayer(Collision collision)
    {
        if (collision.gameObject.GetComponent<Jugador>())
        {
            collision.gameObject.GetComponent<Jugador>().Morir();
            ReturnProyectile();
        }
    }
}
