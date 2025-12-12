using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Jugador : Entity
{
    [Header("Stats Holder")]
    [SerializeField] PlayerStatsHolder stats;

    [Header("Valores de jugador")]

    [SerializeField] public GameObject model; 
    
    [SerializeField] int _vidasActuales;
    public Transform target;
    [SerializeField]AudioSource _audio;

    public UnityAction<Transform> OnTarget;
    
    private void Awake()
    {

        //GameManager.instance.pj = this;
        _animator = model.GetComponent<Animator>();
        _audio = gameObject.GetComponent<AudioSource>();
        //Load();
        model.SetActive(true);
        //EventManager.player.OnStartRun += SetPlayer;

        EventManager.player.GetTarget += TakeTarget;
        print("Inicio");
        _fsm = new FSM();
       
        _fsm.CreateState("Idle", new IdlePlayer(_fsm, this, _animator, stats));
        _fsm.CreateState("Attack", new AttackPlayer(_fsm, this, stats, _animator));
        _fsm.CreateState("Falling", new FallingPlayer(this, _fsm, _animator, stats));
        _fsm.ChangeState("Idle");

        //_fsm.isActive = false;
        //EventManager.player.OnSpawn?.Invoke();
        EventManager.enemy.OnHitted += OnHitted;

        EventManager.playerSetup.OnStarted += SetPlayer;
        EventManager.playerSetup.OnFinished += OnFinishedAnimation;

        EventManager.player.OnDead += OnDead;
    }


    public void SetPlayer()
    {
        target = null;
        _fsm.isActive = false;
        _fsm.ChangeState("Idle");
        GameManager.instance.pj = this;
    }

    public void OnFinishedAnimation()
    {
        _fsm.isActive = true;
    }

    public void Update()
    {
        

        _fsm.Execute();

    }
    

    private void Start()
    {
        rb.useGravity = false;
        //EventManager.level.SceneChanged += SetPlayer;
    }

    public void TakeMoney(int money)
    {
        stats.stats.monedas += money;
    }

    public void TakeTarget(Transform target)
    {
        this.target = target;
        OnTarget?.Invoke(target);
    }

    public override void Morir()
    {
        //DatosJugador.Instance.Save();
        //SceneManager.LoadScene(2);
        _fsm.isActive = false;
        model.SetActive(false);
        EventManager.player.OnDead?.Invoke();
    }

    //public void Impacto(Vector3 Objetivo)
    //{
        
    //    _audio.Play();
    //    dir = (Objetivo - transform.position).normalized;
    //    _runEmpezada = true;
    //    _isDashing = false;
    //    concentracionTimeCurr = 0;
       
    //    ImpulsoDir.y = -dir.y * ImpulsoDistancia;
    //    ImpulsoDir.x = -dir.x * ImpulsoDistancia;

    //    for (float i = 0; i < _repImpactoMax; i++)
    //    {

    //        rb.AddForce(ImpulsoDir);
    //    }
    //    //target = default;
        
    //}

    public void OnDead()
    {
        EventManager.enemy.OnHitted -= OnHitted;
        EventManager.player.GetTarget -= TakeTarget;
        EventManager.playerSetup.OnStarted -= SetPlayer;
        EventManager.playerSetup.OnFinished -= OnFinishedAnimation;

        EventManager.player.OnDead -= OnDead;
    }
    public void OnHitted()
    {
        _audio?.Play();
    }




}
