using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Jugador : Entity
{

    [Header("Valores de jugador")]
    Jugador_PlayerPref _playerPrefs;

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
    public bool _isDashing = false;
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

        _playerPrefs = new Jugador_PlayerPref(vidasMax , maxSpeed ,concentracionTime);

        _playerPrefs.Stats();

        maxSpeed = PlayerPrefs.GetFloat("Velocidad de Dash");
        concentracionTime = PlayerPrefs.GetFloat("Tiempo de concentracion");
        vidasMax = PlayerPrefs.GetInt("Vidas maximas");

    }

    public override void Morir()
    {
        print("Morir");
    }

    public void Impacto(Vector3 Objetivo)
    {
        
        dir = (Objetivo - transform.position).normalized;
        _runEmpezada = true;
        _isDashing = false;
        concentracionTimeCurr = 0;
       
        ImpulsoDir.y = -dir.y * ImpulsoDistancia;
        ImpulsoDir.x = -dir.x * ImpulsoDistancia;

        print("Impacta");

        for (float i = 0; i < _repImpactoMax; i++)
        {
            print("Caida lenta");
            rb.AddForce(ImpulsoDir);
        }
        //target = default;
        print("A");
    }
    
    
}
