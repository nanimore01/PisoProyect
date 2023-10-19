using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IDashable
{
    [SerializeField] private float _speed = 0.1f, _maxDistance = 50f, _currentDistance = 0f;

    void Update()
    {
        var distanceToTravel = _speed * Time.deltaTime;

        transform.position += transform.forward * distanceToTravel;

        _currentDistance += distanceToTravel;
        if(_currentDistance > _maxDistance)
        {
            ProjectileFactory.Instance.ReturnProjectile(this);
        }
    }

    private void Reset()
    {
        _currentDistance = 0;
    }

    public static void TurnOnOff(Projectile p, bool active = true)
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
        if (collision.gameObject.GetComponent<Piso>()) ProjectileFactory.Instance.ReturnProjectile(this);

        if(collision.collider.GetComponent<Jugador>())
        {
            if(collision.collider.gameObject.GetComponent<Jugador>()._isDashing!)
                collision.collider.GetComponent<Jugador>().Morir();

            collision.collider.GetComponent<Jugador>().rb.velocity = Vector3.zero;
            ProjectileFactory.Instance.ReturnProjectile(this);
        }
        
    }
}
