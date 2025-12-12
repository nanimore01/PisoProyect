using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemigoTorreta : EnemigoBase
{

    [SerializeField] private Transform _target;
    [SerializeField] private Transform _spawnPos;
    [SerializeField] private float _velocidadDeRotacion, _viewAngle, _viewRadius;
    public float _speedShot;
    [SerializeField] ProjectileBase _projectile;
    [SerializeField] LayerMask _maskWall;

    public UnityEvent OnDead;

    void Start()
    {
        _fsm = new FSM();

        _fsm.CreateState("Patrol", new PatrolTorreta(this, _velocidadDeRotacion, _spawnPos, _animator));
        _fsm.CreateState("Shot", new ShotTargetTorreta(this, _animator, _speedShot));

        _fsm.ChangeState("Patrol");

    }

    public override void Morir()
    {
        EventManager.enemy.OnDead?.Invoke();
        OnDead.Invoke();
        _animator.SetBool("Dead", true);
        _boxC.enabled = false;
        print("Muerte");
    }
    void Update()
    {
        _fsm.Execute();
    }

    public void ShotProyectile()
    {
        _projectile.SpawnProyectile(_spawnPos);
    }

    public void OnDetect()
    {
        _fsm.ChangeState("Shot");
    }
    public bool InFOV(Transform obj)
    {
        var dir = obj.position - transform.position;

        if (dir.magnitude < _viewRadius)
        {
            if (Vector3.Angle(transform.forward, dir) <= _viewAngle * 0.5f)
            {
                return InLineOfSight(transform.position, obj.position);
            }
        }

        return false;
    }

    public bool InLineOfSight(Vector3 start, Vector3 end)
    {
        var dir = end - start;

        return !Physics.Raycast(start, dir, dir.magnitude, _maskWall);
    }

    public void OnDeadAnimationEnd()
    {
        print("Finished Animation");
        gameObject.SetActive(false);
    }
}
    

