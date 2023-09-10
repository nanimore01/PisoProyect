using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Jugador : Entity
{

    [Header("Valores de jugador")]
    
    public static Jugador instance;
    public int vidasMax;
    [SerializeField] int _vidasActuales;
    public float concentracionTime;
    [SerializeField] public float concentracionTimeCurr;
    public Transform target;
    [SerializeField] float _repImpactoMax;
    public Vector3 dir;
    public Vector3 ImpulsoDir;
    public float ImpulsoDistancia;
    bool _runEmpezada = false;
    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, maxSpeed);
        }
        concentracionTimeCurr += Time.deltaTime;
        if (concentracionTimeCurr > concentracionTime && _runEmpezada)
        {
            rb.useGravity = true;
            print("tiempo fuera");
        }

    }

    
    private void Start()
    {
        rb.useGravity = false;
    }

    public override void Morir()
    {
        
    }

    public void Impacto(Vector3 target)
    {
        dir = target - transform.position;
        _runEmpezada = true;
        if (dir.y < 0)
        {
            ImpulsoDir.y = ImpulsoDistancia;
        }
        else
        {
            ImpulsoDir.y = -ImpulsoDistancia;
        }

        if(dir.x < 0)
        {
            ImpulsoDir.x = ImpulsoDistancia;
        }
        else
        {
            ImpulsoDir.x = -ImpulsoDistancia;
        }
        print("Impacta");

        for (float i = 0; i < _repImpactoMax; i++)
        {
            print("Caida lenta");
            rb.AddForce(ImpulsoDir);
        }
    }
    
    
}
