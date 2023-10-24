using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTargetTorreta : IState
{
    FSM _fsm;
    Transform _target, _transform, _spawnPos;
    float _cooldown, _currCooldown;

    public ShotTargetTorreta(FSM fsm, Transform torreta, Transform SpawnPos, float Cooldown) 
    {
        _fsm = fsm;
        _transform = torreta;
        _spawnPos = SpawnPos;
        _cooldown = Cooldown;
        
    }


    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        _currCooldown += Time.deltaTime;
        _target = Jugador.instance.transform;
        _transform.LookAt(_target);

        if(_currCooldown > _cooldown)
        {
            var p = ProjectileFactory.Instance.pool.GetObject();
            p.transform.SetPositionAndRotation(_spawnPos.transform.position, _spawnPos.rotation.normalized);
            _currCooldown = 0;
        }
    }
}
