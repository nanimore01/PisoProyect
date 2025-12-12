using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "PlayerStatsHolder", menuName = "ScriptableObject/StatsEnemigos")]
public class PlayerStatsHolder : ScriptableObject
{
    [Header("Speed stats")]
    public EntityStats speedStats;
    [Header("Base stats")]
    public PlayerStats stats;

    public List<Abilities> hablilidades = new List<Abilities>();

    
}
