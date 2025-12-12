using UnityEngine;

public class BuySlowmotion : PoderBase
{
    [SerializeField] Abilities abilities;
    public override void OnBuy(PlayerStatsHolder statsHolder)
    {
        statsHolder.hablilidades.Add(abilities);
    }
}
