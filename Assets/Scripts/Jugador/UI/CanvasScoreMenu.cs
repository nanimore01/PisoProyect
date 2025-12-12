using UnityEngine;

public class CanvasScoreMenu : MonoBehaviour
{
    [SerializeField] Canvas _canvas;
    [SerializeField] Animator _animator;

    public void Awake()
    {
        EventManager.player.OnDead += OnPlayerDie;
    }

    public void OnEnable()
    {
        EventManager.player.OnDead += OnPlayerDie;
    }

    private void OnDisable()
    {
        EventManager.player.OnDead -= OnPlayerDie;
    }

    public void OnPlayerDie()
    {
        _canvas.gameObject.SetActive(true);
        _animator.SetBool("IsActive", true);
        EventManager.player.OnDead -= OnPlayerDie;
    }

}
