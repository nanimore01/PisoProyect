using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public static class EventManager
{
    public static readonly PlayerEvents player = new PlayerEvents();
    public static readonly EnemyEvents enemy = new EnemyEvents();
    public static readonly ObstacleEvents obstacle = new ObstacleEvents();
    public static readonly LevelEvents level = new LevelEvents();
    public static readonly PlayerSetupEvents playerSetup = new PlayerSetupEvents();
    public static readonly ShopEvent shop = new ShopEvent();

    public class ShopEvent
    {
        public UnityAction<int> OnShopOpen;
        public UnityAction<int> OnBuyAnItem;
        public UnityAction OnCantBuy;
        public UnityAction OnBuyAbility;
    }

    public class EnemyEvents
    {
        public UnityAction OnDead;
        public UnityAction OnHitted;
        public UnityAction OnTargetTrap;
        public UnityAction OnTargetEnemy;
    }

    public class ObstacleEvents
    {
        public UnityAction OnDestroyed;
    }

    public class LevelEvents
    {
        public UnityAction OnSceneNotCharged;
        public UnityAction<float> OnLoadingScene;
        public UnityAction SceneChanged;
    }

    public class PlayerEvents
    {
        public UnityAction OnStartRun;
        public UnityAction OnLostALife;
        public UnityAction OnDead;
        public UnityAction<float> OnFalling;
        public UnityAction Fall;
        public UnityAction OnAttack;
        public UnityAction TargetOn;
        public UnityAction<Transform> GetTarget;
        public UnityAction OnConcentrationOff;
        
    }

    public class PlayerSetupEvents
    {
        public UnityAction OnStarted;
        public UnityAction OnFinished;
    }

}
