using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoTorreta : EnemigoBase
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _spawnPos = default;
    public float CoolDown = 2;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_target.position);
        timer += Time.deltaTime;

        if (CoolDown <= timer)
        {
            var p = ProjectileFactory.Instance.pool.GetObject();
            //p.transform.position = transform.position;
            p.transform.SetPositionAndRotation(_spawnPos.position, _spawnPos.rotation);
            //p.transform.forward = Vector3.forward;
            timer = 0;
        }
    }
}
