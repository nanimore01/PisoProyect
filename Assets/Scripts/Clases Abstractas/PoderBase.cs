using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class PoderBase : MonoBehaviour
{
    public TextMeshProUGUI textoPrecio;
    [SerializeField]protected PlayerStatsHolder _playerStats;
    public int precio;

    public void Awake()
    {
        EventManager.shop.OnShopOpen += ConfigText;
        EventManager.shop.OnBuyAnItem += ConfigText;
    }

    public abstract void OnBuy(PlayerStatsHolder statsHolder);

    public void OnTryToBuy(PlayerStatsHolder statsHolder)
    {
        //print(ICanBuyIt(statsHolder.stats.monedas));

        if (statsHolder.stats.monedas > precio && PlayerPrefs.GetInt("Energy") > 0)
        {
            
            statsHolder.stats.monedas -= precio;
            OnBuy(statsHolder);
            EventManager.shop.OnBuyAnItem?.Invoke(statsHolder.stats.monedas);
        }
        else
        {
            EventManager.shop.OnCantBuy?.Invoke();
        }

        
    }

    public bool ICanBuyIt(int money)
    {
        return money > precio;
    }

    public void ConfigText(int money)
    {
        if(ICanBuyIt(money))
        {
            textoPrecio.color = Color.green;
        }
        else
        {
            textoPrecio.color = Color.red;
        }

        textoPrecio.text = precio + "$";

    }

}
