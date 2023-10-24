using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolTorreta : IState
{
    FSM _fsm;
    Transform _transform, _spawnPos;
    float _velocidadDeRotacion;
    Ray _ray;
    RaycastHit _hit;


    public PatrolTorreta(FSM fsm, Transform transform, float _velocidad, Transform spawnPos, Ray ray, RaycastHit hit)
    {
        _fsm = fsm;
        _transform = transform;
        _velocidadDeRotacion = _velocidad;
        _spawnPos = spawnPos;
        _ray = ray;
        _hit = hit;
    }

    public void OnEnter()
    {
        
    }

    public void OnExit()
    {
        
    }

    public void OnUpdate()
    {
        _transform.Rotate(new Vector3(0, _velocidadDeRotacion * Time.deltaTime, 0));

        _ray = new Ray(_spawnPos.transform.position, _spawnPos.forward);
        Debug.DrawRay(_ray.origin, _ray.direction);
        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.GetComponent<Jugador>() != null)
            {
                _fsm.ChangeState("Shot");
            }
        }
    }
}
