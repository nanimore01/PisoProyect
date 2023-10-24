using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTorreta : EnemigoBase
{
    FSM _fsm;

    [SerializeField] private Transform _target;
    [SerializeField] private Transform _spawnPos = default;
    [SerializeField] private Ray _ray;
    [SerializeField] private RaycastHit _hit;
    [SerializeField] private float _velocidadDeRotacion;
    public float coolDown = 2;
    

    
    
    void Start()
    {
        _tamaño = FlyWeightPointer.EnemigoTorreta.weight;
        _monedasDadas = FlyWeightPointer.EnemigoTorreta.monedasDadas;

        _fsm = new FSM();

        _fsm.CreateState("Patrol", new PatrolTorreta(_fsm, transform, _velocidadDeRotacion, _spawnPos, _ray, _hit));
        _fsm.CreateState("Shot", new ShotTargetTorreta(_fsm, transform, _spawnPos, coolDown));

        _fsm.ChangeState("Patrol");

    }

    
    void Update()
    {

        _fsm.Execute();

       /* if(_target)
        {
            transform.LookAt(_target.position);
        }

        transform.Rotate(new Vector3(0, _velocidadDeRotacion * Time.deltaTime, 0));
        
        timer += Time.deltaTime;
        _ray = new Ray(_spawnPos.transform.position, _spawnPos.forward);
        Debug.DrawRay(_ray.origin, _ray.direction);
        if (Physics.Raycast(_ray, out _hit))
        {
            if(_hit.collider.GetComponent<Jugador>() != null)
            {
                _target = Jugador.instance.transform;
                if (CoolDown <= timer)
                {
                    var p = ProjectileFactory.Instance.pool.GetObject();
                    p.transform.SetPositionAndRotation(_spawnPos.transform.position, _spawnPos.rotation.normalized);
                    timer = 0;
                }
            }



        }
       
        Voy a tener esto comentado por si las dudas
        

        */
        
    }

    
}
