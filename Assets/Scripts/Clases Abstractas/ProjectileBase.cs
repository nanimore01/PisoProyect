using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ProjectileBase : MonoBehaviour, IDashable
{
    [SerializeField] private float _speed, _maxDistance;
    protected CountdownTimer _timer;
    [SerializeField] protected delegate void ProyectileMovement();
    [SerializeField] protected ProyectileMovement movement;
    [SerializeField] protected UnityEvent<Collision> collisionBeheviour;


    public virtual void Awake()
    {
        movement = DefaultMovement;
        _timer = new CountdownTimer(_maxDistance);
        _timer.OnTimerStop += OnDistanceCompleted;
        _timer.Start();
    }

    void Update()
    {
        movement.Invoke();
        
    }

    public void DefaultMovement()
    {
        _timer.Tick(Time.deltaTime * _speed);
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
    
    public void OnDistanceCompleted()
    {
        ReturnProyectile();
    }

    public virtual void Reset()
    {
        _timer.Reset();
        _timer.Start();
    }

    public static void TurnOnOff(ProjectileBase p, bool active = true)
    {
        if (active)
        {
            p.Reset();
        }
        p.gameObject.SetActive(active);
    }
    public void ActiveDash()
    {
        EventManager.player.GetTarget?.Invoke(transform);
        EventManager.enemy.OnTargetTrap?.Invoke();
    }

    public abstract void SpawnProyectile(Transform transform);
    public abstract void ReturnProyectile();
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Piso>()) 
            ReturnProyectile();

        collisionBeheviour?.Invoke(collision);
    }
}
