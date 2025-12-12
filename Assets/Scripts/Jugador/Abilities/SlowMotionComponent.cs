using UnityEngine;

public class SlowMotionComponent : Abilities
{
    CountdownTimer _timer;
    [SerializeField] PlayerStatsHolder stats;
    public void Awake()
    {
        _timer = new CountdownTimer(stats.stats.slowmotionTime);

        EventManager.enemy.OnTargetTrap += OnActiveSlowmotion;

        EventManager.enemy.OnTargetEnemy += OnTargetEnemy;

        EventManager.player.OnDead += OnDead;
        _timer.OnTimerStop += OnDisactiveSlowMotion;
    }

    public void Update()
    {
        _timer.Tick(Time.deltaTime);
    }

    public void OnActiveSlowmotion()
    {
        _timer.Reset();
        _timer.Start();

        Time.timeScale = 0.5f;
    }

    public void OnTargetEnemy()
    {
        _timer.Stop();
    }

    public void OnDisactiveSlowMotion()
    {
        Time.timeScale = 1f;
        print("Tiempo normal");
    }

    public override void OnDead()
    {
        EventManager.enemy.OnTargetTrap -= OnActiveSlowmotion;
        EventManager.enemy.OnTargetEnemy -= OnTargetEnemy;
        Time.timeScale = 1f;
        EventManager.player.OnDead -= OnDead;
    }

    private void OnDisable()
    {
        EventManager.enemy.OnTargetTrap -= OnActiveSlowmotion;
        Time.timeScale = 1f;
        EventManager.enemy.OnTargetEnemy -= OnTargetEnemy;
        EventManager.player.OnDead -= OnDead;
    }
}
