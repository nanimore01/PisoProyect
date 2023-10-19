using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTorreta : EnemigoBase
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _spawnPos = default;
    [SerializeField] private Ray _ray;
    [SerializeField] private RaycastHit _hit;
    [SerializeField] private float _velocidadDeRotacion;
    public float CoolDown = 2;
    public float timer = 0;
    // Start is called before the first frame update
    
    void Start()
    {
        _tamaño = FlyWeightPointer.EnemigoTorreta.weight;
        _monedasDadas = FlyWeightPointer.EnemigoTorreta.monedasDadas;
    }

    // Update is called once per frame
    void Update()
    {
        if(_target)
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

        
    }

    
}
