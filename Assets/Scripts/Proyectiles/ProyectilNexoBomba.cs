using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilNexoBomba : ProyectilNexoBase
{
    public void Update()
    {
        Movimiento();
        if (_currentDistance > _maxDistance)
        {

        }
    }

    public static void TurnOnOff(ProyectilNexoBomba p, bool active = true)
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
            NexoBombaFactory.Instance.ReturnProjectile(this);
        }

        if (collision.gameObject.GetComponent<Jugador>() && collision.gameObject.GetComponent<Jugador>()._isDashing)
        {
            collision.gameObject.GetComponent<Jugador>().Morir();
            NexoBombaFactory.Instance.ReturnProjectile(this);
        }
    }
}
