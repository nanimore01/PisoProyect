using UnityEngine;
using TMPro;

public class UICoinText : MonoBehaviour
{
    [SerializeField] PlayerStatsHolder stats;
    [SerializeField] TMP_Text _text;
    [SerializeField] Animator _animator;

    public void OnEnable()
    {
        EventManager.enemy.OnDead += UpdateText;
        EventManager.player.OnDead += HideUI;
    }

    public void OnDisable()
    {
        EventManager.enemy.OnDead -= UpdateText;
        EventManager.player.OnDead -= HideUI;

    }

    public void Awake()
    {
        _text = gameObject.GetComponent<TMP_Text>();

        UpdateText();
    }

    public void UpdateText()
    {
        _text.text = stats.stats.monedas.ToString("C");
    }

    public void HideUI()
    {
        _animator.SetBool("IsActive", false);
    }
}
