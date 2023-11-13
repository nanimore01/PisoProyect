using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ProyectilNexo : MonoBehaviour, IDashable
{
    [SerializeField] private float _maxDistance = 5f, _currentDistance = 0f;
    public float speed = 0.01f;

    void Update()
    {
        var distanceToTravel = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position,Nexo.instance.transform.position, speed);
        _currentDistance += distanceToTravel;
        if (_currentDistance > _maxDistance)
        {
            NexoBulletFactory.Instance.ReturnProjectile(this);
        }
    }

    private void Reset()
    {
        _currentDistance = 0;
    }

    public static void TurnOnOff(ProyectilNexo p, bool active = true)
    {
        if (active)
        {
            p.Reset();
        }
        p.gameObject.SetActive(active);
    }
    public void ActiveDash()
    {
        Jugador.instance._isDashing = true;
        Jugador.instance.target = transform;
        Jugador.instance.rb.useGravity = false;
        Jugador.instance.rb.velocity = Vector3.zero;
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
