using UnityEngine;

public class IdlePlayer : IState
{
    Jugador _me;
    FSM _fsm;
    Animator _animator;
    PlayerStatsHolder _stats;
    CountdownTimer _timerConcentracion;

    Rigidbody _rb;
    public IdlePlayer(FSM fsm, Jugador pj, Animator animator, PlayerStatsHolder stats)
    {
        _fsm = fsm;
        _me = pj;
        _animator = animator;
        _stats = stats;

        _timerConcentracion = new CountdownTimer(_stats.stats.concentracionTime);
        _timerConcentracion.OnTimerStop = OnConcentrationOff;
        _rb = pj.rb;

        EventManager.player.OnDead += OnDead;
    }

    public void OnEnter()
    {
        _rb.useGravity = false;
        _rb.velocity = Vector3.zero;
        EventManager.level.SceneChanged += OnRunStarted;
        
    }
    public void OnDead()
    {
        EventManager.level.SceneChanged -= OnRunStarted;

        EventManager.player.OnDead -= OnDead;
    }
    public void OnRunStarted()
    {
        _timerConcentracion.Start();
        EventManager.player.Fall?.Invoke();
    }

    public void OnExit()
    {
        EventManager.player.OnStartRun?.Invoke();
        _animator.SetBool("IsDashing", true);
    }


    public void OnUpdate()
    {
        _timerConcentracion.Tick(Time.deltaTime);
        EventManager.player.OnFalling.Invoke(_timerConcentracion.Time);
        if(_me.target != null)
        {
            _fsm.ChangeState("Attack");
        }
    }

    public void OnConcentrationOff()
    {
        _rb.useGravity = true;
        EventManager.player.OnConcentrationOff?.Invoke();
    }

    

}
