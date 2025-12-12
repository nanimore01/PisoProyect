using UnityEngine;

public class AttackPlayer : IState
{
    Jugador _me;
    Rigidbody _rb;
    FSM _fsm;
    Animator _animator;

    float _maxForce;
    float _maxVelocity;
    Vector3 _velocity;

    public AttackPlayer(FSM fsm, Jugador pj, PlayerStatsHolder stats, Animator animator)
    {
        _me = pj;
        _fsm = fsm;
        _animator = animator;
        _rb = _me.gameObject.GetComponent<Rigidbody>();
        _maxForce = stats.speedStats.maxForce;
        _maxVelocity = stats.speedStats.maxVelocity;

        EventManager.player.OnDead += OnDead;
    }

    public void OnEnter()
    {
        _rb.useGravity = false;
        _rb.velocity = Vector3.zero;
        EventManager.enemy.OnHitted += OnExpulsed;
        EventManager.level.SceneChanged += OnHitted;
    }

    public void OnExit()
    {
        EventManager.enemy.OnHitted -= OnExpulsed;
        EventManager.level.SceneChanged -= OnHitted;
        _animator?.SetFloat("Velocity", 0);
    }

    public void OnDead()
    {
        EventManager.enemy.OnHitted -= OnExpulsed;
        EventManager.level.SceneChanged -= OnHitted;

        EventManager.player.OnDead -= OnDead;
    }

    public void OnUpdate()
    {
        //if(Vector3.Distance(_me.transform.position, _me.target.transform.position) < 0.5f)
        //{
        //    _fsm.ChangeState("Falling");
        //}

        //_animator.SetFloat("Velocity", Vector3.Distance(_me.transform.position, _me.target.transform.position));
        _animator?.SetFloat("Velocity", _velocity.magnitude);
        AddForce(Seek(_me.target.transform.position));

        _me.transform.position += _velocity * Time.deltaTime;
        _me.transform.forward = _velocity;

        EventManager.player.OnAttack?.Invoke();
    }

    public void OnHitted()
    {
        _fsm.ChangeState("Idle");
    }

    public void OnExpulsed()
    {
        _fsm.ChangeState("Falling");
    }

    Vector3 Seek(Vector3 dir)
    {
        var desired = dir - _me.transform.position;
        desired.Normalize();
        desired *= _maxVelocity;

        var steering = desired - _velocity;
        steering = Vector3.ClampMagnitude(steering, _maxForce);

        return steering;
    }

    void AddForce(Vector3 dir)
    {
        _velocity += dir;

        _velocity = Vector3.ClampMagnitude(_velocity, _maxVelocity);
    }

}
