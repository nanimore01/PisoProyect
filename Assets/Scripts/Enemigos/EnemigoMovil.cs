using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoMovil : EnemigoBase
{
    Vector3 _velocity;
    public float maxVelocity;
    public Transform[] wayPoints;
    public int _currentWaypoint;

    public void Start()
    {
        _tamaño = FlyWeightPointer.EnemigoMovil.weight;
        _monedasDadas = FlyWeightPointer.EnemigoMovil.monedasDadas;
    }

    public Vector3 velocity
    {
        get { return _velocity; }
    }
    void Update()
    {
        AddForce(Seek(wayPoints[_currentWaypoint].position));

        if (Vector3.Distance(wayPoints[_currentWaypoint].position, transform.position) <= 0.2f)
        {
            _currentWaypoint++;
            if (_currentWaypoint >= wayPoints.Length)
            {
                _currentWaypoint = 0;
            }
        }
        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
    }

    Vector3 Seek(Vector3 dir)
    {
        var desired = dir - transform.position;
        desired.Normalize();
        desired *= maxVelocity;

        var steering = desired - _velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);

        return steering;
        //AddForce(steering);
    }

    void AddForce(Vector3 dir)
    {
        _velocity += dir;

        _velocity = Vector3.ClampMagnitude(_velocity, maxVelocity);
    }
}
