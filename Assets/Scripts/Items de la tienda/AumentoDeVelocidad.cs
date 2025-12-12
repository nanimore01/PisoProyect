using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoDeVelocidad : PoderBase
{
    private void Start()
    {

        precio = Mathf.RoundToInt(10 + (10 * _playerStats.speedStats.maxVelocity));



        textoPrecio.text = precio.ToString();
    }

    public override void OnBuy(PlayerStatsHolder statsHolder)
    {
        statsHolder.speedStats.maxVelocity += 0.1f;
        
        precio = Mathf.RoundToInt(10 + (10 * statsHolder.speedStats.maxVelocity));
    }
}
