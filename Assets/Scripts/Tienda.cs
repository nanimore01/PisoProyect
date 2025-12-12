using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Tienda : MonoBehaviour
{
    public PlayerStatsHolder stats;
    [SerializeField] TMP_Text _moneyText;
    [SerializeField] Animator _animator;
    [SerializeField] AudioSource _audio;
    [SerializeField] CanvasManager _canvas;
    public void Start()
    {


        EventManager.shop.OnShopOpen += UpdateText;

        EventManager.shop.OnShopOpen?.Invoke(stats.stats.monedas);
        
        EventManager.shop.OnBuyAnItem += UpdateText;
    }

    public void UpdateText(int money)
    {
        _moneyText.text = money + "$";
    }

    public void GoToCanvas()
    {
        _canvas.EnableMenu(_animator.GetInteger("Canvas"));
    }

    public void PlayAnimationGoToShop()
    {
        _animator.SetInteger("Canvas", 1);
        _animator.SetBool("IsActive", false);
        
    }

}
