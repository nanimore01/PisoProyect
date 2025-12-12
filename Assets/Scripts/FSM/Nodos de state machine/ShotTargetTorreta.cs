using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotTargetTorreta : IState
{
    EnemigoTorreta _me;
    Animator _animator;
    float _desiredDuration;
    public ShotTargetTorreta(EnemigoTorreta me, Animator animator, float desiredDuration) 
    {
        _me = me;
        _animator = animator;
        _desiredDuration = desiredDuration;

        _me.OnDead.AddListener(OnDead);
    }


    public void OnEnter()
    {
        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
        float originalClipLength = stateInfo.length;

        // Calcular la nueva velocidad
        float newSpeed = originalClipLength / _desiredDuration;

        // Asignar la velocidad al Animator
        _animator.speed = newSpeed;
        _animator.SetBool("Attack", true);

    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        Vector3 viewPlayer = new Vector3(GameManager.instance.pj.transform.position.x, GameManager.instance.pj.transform.position.y, 0);
        _me.transform.LookAt(GameManager.instance.pj.transform);

        //if (_currCooldown > _cooldown)
        //{
        //    var p = ProjectileFactory.Instance.pool.GetObject();
        //    p.transform.SetPositionAndRotation(_spawnPos.transform.position, _spawnPos.rotation.normalized);

        //}
    }

    public void OnDead()
    {
        _animator.speed = 1;
    }
}
