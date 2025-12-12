using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentoDeConcentracion : PoderBase
{
    
    

    private void Start()
    {
        precio = Mathf.RoundToInt(20 + (10 * _playerStats.stats.concentracionTime));
        textoPrecio.text = precio.ToString();
    }

    public override void OnBuy(PlayerStatsHolder stats)
    {
        stats.stats.concentracionTime += 0.1f;
        precio = Mathf.RoundToInt(20 + (10 * stats.stats.concentracionTime));
    }

}
