using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] Jugador _pj;
    [SerializeField] Transform _end, _start;
    CountdownTimer _timer;

    public void Start()
    {
        EventManager.level.SceneChanged += OnChangeScene;
        EventManager.player.OnDead += OnDead;
        _timer = new CountdownTimer(1);
        OnChangeScene();
        _timer.OnTimerStop += OnTimerStop;
        _timer.Start();
    }

    public void OnChangeScene()
    {
        _pj.transform.position = _start.transform.position;
        _pj.transform.rotation = _start.transform.rotation;
        _timer.Reset();
        _timer.Start();
        EventManager.playerSetup.OnStarted?.Invoke();
    }

    public void OnDead()
    {
        EventManager.level.SceneChanged -= OnChangeScene;

        EventManager.player.OnDead -= OnDead;
    }

    public void OnTimerStop()
    {
        EventManager.playerSetup.OnFinished?.Invoke();
    }

    public void Update()
    {
        _timer.Tick(Time.deltaTime);

        if(_timer.IsRunning)
        {
            SetJugador(_timer.Progress);
        }
    }

    public void SetJugador(float t)
    {
        _pj.transform.position = Vector3.Lerp(_end.position, _start.position, t);
    }
}
