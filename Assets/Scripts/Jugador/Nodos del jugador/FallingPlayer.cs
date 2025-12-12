using UnityEngine;

public class FallingPlayer : IState
{
    Jugador _me;
    FSM _fsm;
    Animator _animator;
    Rigidbody _rb;

    Vector3 _dir;
    Vector3 _impulsoDir;

    CountdownTimer _timer;
    float _impulsoDistancia;
    float _repImpactoMax;

    public FallingPlayer(Jugador pj, FSM fsm, Animator animator, PlayerStatsHolder stats)
    {
        _me = pj;
        _fsm = fsm;
        _animator = animator;
        _rb = _me.gameObject.GetComponent<Rigidbody>();

        _timer = new CountdownTimer(stats.stats.concentracionTime);
        _timer.OnTimerStop = OnConcentrationOff;

        _impulsoDistancia = stats.stats.impulsoDistancia;
        _repImpactoMax = stats.stats.repImpactoMax;

        EventManager.player.OnDead += OnDead;
    }

    public void OnEnter()
    {
        EventManager.player.Fall?.Invoke();
        EventManager.player.TargetOn += OnTarget;

        _timer.Reset();
        _timer.Start();
        Impacto(_me.target.position);
    }

    public void OnExit()
    {
        EventManager.player.TargetOn -= OnTarget;
    }

    public void OnDead()
    {
        EventManager.player.TargetOn -= OnTarget;

        EventManager.player.OnDead -= OnDead;
    }

    public void OnUpdate()
    {
        _timer.Tick(Time.deltaTime);
        EventManager.player.OnFalling?.Invoke(_timer.Time);
    }

    public void OnConcentrationOff()
    {
        _rb.useGravity = true;
        EventManager.player.OnConcentrationOff?.Invoke();
    }

    public void OnTarget()
    {
        _fsm.ChangeState("Attack");
    }

    public void Impacto(Vector3 Objetivo)
    {

        //_audio.Play();
        _dir = (Objetivo - _me.transform.position).normalized;
        
        //_concentracionTimeCurr = 0;

        _impulsoDir.y = -_dir.y * _impulsoDistancia;
        _impulsoDir.x = -_dir.x * _impulsoDistancia;

        for (float i = 0; i < _repImpactoMax; i++)
        {
            _rb.AddForce(_impulsoDir);
        }
        //target = default;

    }
}
