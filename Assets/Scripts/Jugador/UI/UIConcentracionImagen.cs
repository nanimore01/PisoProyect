using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIConcentracionImagen : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] TMP_Text _text;
    [SerializeField] Animator _animator;
    [SerializeField] PlayerStatsHolder _pj;
    public void OnEnable()
    {
        EventManager.player.OnFalling += UpdateUI;
        EventManager.player.Fall += OnFalling;
        EventManager.player.TargetOn += FallStoped;
        EventManager.player.OnConcentrationOff += FallStoped;
    }

    public void OnDisable()
    {
        EventManager.player.OnFalling -= UpdateUI;
        EventManager.player.Fall -= OnFalling;
        EventManager.player.TargetOn -= FallStoped;
        EventManager.player.OnConcentrationOff -= FallStoped;
    }

    public void Awake()
    {
        
    }

    public void OnFalling()
    {
        _image.enabled = true;
        _text.enabled = true;
    }

    public void FallStoped()
    {
        _image.enabled = false;
        _text.enabled = false;
    }

    public void UpdateUI(float time)
    {
        _image.fillAmount = time / _pj.stats.concentracionTime;

        _text.text = time.ToString("N");

        if (time <= 0)
            _text.enabled = false;
    }
}
