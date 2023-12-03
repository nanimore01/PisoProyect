using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ProyectilNexo : ProyectilNexoBase
{
    void Update()
    {
        Movimiento();
        if (_currentDistance > _maxDistance)
        {
            NexoBulletFactory.Instance.ReturnProjectile(this);
        }
    }

    public static void TurnOnOff(ProyectilNexo p, bool active = true)
    {
        if (active)
        {
            p.Reset();
        }
        p.gameObject.SetActive(active);
    }
   

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Nexo>())
        {
            collision.gameObject.GetComponent<Nexo>().dano();
            NexoBulletFactory.Instance.ReturnProjectile(this);
        }


        if (collision.collider.GetComponent<Jugador>())
        {
            collision.collider.GetComponent<Jugador>().target = null;
            collision.collider.GetComponent<Jugador>().rb.velocity = Vector3.zero;
            collision.collider.GetComponent<Jugador>().Impacto(transform.position);
            NexoBulletFactory.Instance.ReturnProjectile(this);
        }

    }
   
}
