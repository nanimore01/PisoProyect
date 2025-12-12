using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolTorreta : IState
{
    EnemigoTorreta _me;
    Transform _spawnPos;
    float _velocidadDeRotacion;
    Ray _ray;
    RaycastHit _hit;
    Animator _animator;

    public PatrolTorreta(EnemigoTorreta me, float _velocidad, Transform spawnPos, Animator animator)
    {
        
        _me = me;
        _velocidadDeRotacion = _velocidad;
        _spawnPos = spawnPos;
        _animator = animator;
    }

    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        _me.transform.Rotate(new Vector3(0, 0, _velocidadDeRotacion * Time.deltaTime));
        Debug.Log(_me.InFOV(GameManager.instance.pj.transform));
        if (_me.InFOV(GameManager.instance.pj.transform))
        {
            _animator.SetBool("Detected", true);
        }
    }
}
