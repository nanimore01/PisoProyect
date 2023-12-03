using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilNexoBase : MonoBehaviour, IDashable
{
    [SerializeField] protected float _maxDistance = 5f, _currentDistance = 0f;
    public float speed = 0.01f;

    public void Movimiento()
    {
        var distanceToTravel = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Nexo.instance.transform.position, speed);
        _currentDistance += distanceToTravel;
    }

    public void Reset()
    {
        _currentDistance = 0;
    }
    public void ActiveDash()
    {
        Jugador.instance._isDashing = true;
        Jugador.instance.target = transform;
        Jugador.instance.rb.useGravity = false;
        Jugador.instance.rb.velocity = Vector3.zero;
    }


}
